using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 20;
    public float speed = 0;

    private float attackTimer = 0;
    private float attackInterval = 2;

    private bool pauseMovement = false;

    public float stunTimer = 2;
    private float stun = 0;

    private NavMeshAgent agent;
    public Transform PlayerTarget;
    public Animator animator;
    public HealthBar healthBar;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0) {
            GetComponent<CircleCollider2D>().enabled = false;
            PauseMovement();
            animator.SetTrigger("Death");
        }
    }

    private void Die() {
        Destroy(gameObject);
    }

    public void PauseMovement() {
        stun = stunTimer;
        pauseMovement = true;
        agent.SetDestination(transform.position);
    }

    private void Update() {
        if (stun > 0) {
            stun -= Time.deltaTime;
        }
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
        if (stun <= 0) {
            pauseMovement = false;
        }

        Vector2 movement;
        movement.x = PlayerTarget.position.x - transform.position.x;
        movement.y = PlayerTarget.position.y - transform.position.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        float distance = Vector2.Distance(PlayerTarget.position, transform.position);
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

    private void OnTriggerStay2D(Collider2D hitInfo) {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null && attackTimer <= 0) {
            player.TakeDamage(damage);
            attackTimer = attackInterval;
        }
    }
}