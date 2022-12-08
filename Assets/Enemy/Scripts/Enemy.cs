using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public int health = 100;
    public int damage = 20;

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

    private void Update() {
        float distance = Vector2.Distance(PlayerTarget.position, transform.position);
        if (distance <= 7.5) {
            agent.SetDestination(PlayerTarget.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null) {
            player.TakeDamage(damage);
        }
    }
}