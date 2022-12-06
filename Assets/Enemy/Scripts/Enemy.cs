using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject paths;

    public int counterPos = 0;
    public float speed = 3f;
    public int damage = 20;

    private NavMeshAgent agent;
    public Transform PlayerTarget;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        var path = paths.GetComponent<Path>();
        Vector3 movepoint;
        float step = speed * Time.deltaTime;

        float distance = Vector2.Distance(PlayerTarget.position, transform.position);
        //Debug.Log(distance);
        if (distance <= 7.5) {
            agent.SetDestination(PlayerTarget.position);
        }
        else {
            if (counterPos == 1) {
                movepoint = path.point2.position;
            }
            else if (counterPos == 2) {
                movepoint = path.point3.position;
            }
            else {
                movepoint = path.point1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, movepoint, step);
            var dist = Vector2.Distance(transform.position, movepoint);
            if (dist <= 0.5f) {
                counterPos += 1;
                Debug.Log(counterPos);
                if (counterPos > 2) {
                    counterPos = 0;
                }
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
