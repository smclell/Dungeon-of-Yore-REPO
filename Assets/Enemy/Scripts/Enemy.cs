using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int health = 100;
    public int damage = 20;
    private bool pauseMovement = false;
    public float stunTimer = 2;
    private float stun = 0;

    private NavMeshAgent agent;
    public Transform PlayerTarget;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Die();
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
        if (stun <= 0) {
            pauseMovement = false;
        }

        float distance = Vector2.Distance(PlayerTarget.position, transform.position);
        if (distance <= 7.5 && distance > 1 && !pauseMovement) {
            agent.SetDestination(PlayerTarget.position);
        }
        else { agent.SetDestination(transform.position); }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null) {
            player.TakeDamage(damage);
        }
    }
}