using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Space]
    [Header("Enemy Stats:")]
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 20;
    public float speed = 0;

    [Space]
    [Header("Attack Info:")]
    private float attackTimer = 0;
    private float attackInterval = 2;

    [Space]
    [Header("Stunning:")]
    private bool pauseMovement = false;
    public float stunTimer = 2;
    private float stun = 0;

    [Space]
    [Header("Navmesh:")]
    private NavMeshAgent agent;
    public Transform PlayerTarget;
    [Space]
    [Header("Animation and Audio:")]
    public Animator animator;
    public HealthBar healthBar;
    public AudioSource audioSource;
    public AudioClip deathSound;

    [Space]
    [Header("Boss info")]
    public bool Boss;
    public int unlockPos;

    private void Start() {
        //setup navmesh
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //setup health and healthbar
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //Taking damage
    public void TakeDamage(int damage) {
        health -= damage;
        healthBar.SetHealth(health);

        //if enemy dies
        if (health <= 0) {
            audioSource.PlayOneShot(deathSound, 0.5f);
            GetComponent<BoxCollider2D>().enabled = false;
            PauseMovement();
            animator.SetTrigger("Death");
        }
    }

    //call after death animation plays to check for boss info to spawn key
    private void Die() {
        Boss boss = GetComponent<Boss>();
        if (boss != null && Boss) { boss.SpawnKey(gameObject.transform, unlockPos); }
        Destroy(gameObject);
    }

    //stop movement for stun
    public void PauseMovement() {
        stun = stunTimer;
        pauseMovement = true;
        agent.SetDestination(transform.position);
    }

    private void Update() {
        //adjusting timers
        if (stun > 0) {
            stun -= Time.deltaTime;
        }
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
        if (stun <= 0) {
            pauseMovement = false;
        }

        //movement
        Vector2 movement;
        movement.x = PlayerTarget.position.x - transform.position.x;
        movement.y = PlayerTarget.position.y - transform.position.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        float distance = Vector2.Distance(PlayerTarget.position, transform.position);

        //setting animations and movement distances
        if (distance <= 7.5 && distance > 0.75 && !pauseMovement) {
            agent.SetDestination(PlayerTarget.position);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else {
            if (!(distance > 7.5)) {
                agent.SetDestination(transform.position);
                animator.SetFloat("Speed", 0);
            }
            else if (distance > 7.5 && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 && agent.remainingDistance != Mathf.Infinity) {
                agent.SetDestination(transform.position);
                animator.SetFloat("Speed", 0);
            }
        }
    }

    //colliding with player to damage them
    private void OnTriggerStay2D(Collider2D hitInfo) {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null && attackTimer <= 0) {
            player.TakeDamage(damage);
            attackTimer = attackInterval;
        }
    }
}