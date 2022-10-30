using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject paths;

    public int counterPos = 0;
    public float speed = 3f;
    public int damage = 20;

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
        if (counterPos == 1)
        {
            movepoint = path.point2.position;
        }
        else if (counterPos == 2)
        {
            movepoint = path.point3.position;
        }
        else
        {
            movepoint = path.point1.position;
        }

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movepoint, step);
        if (gameObject.transform.position == movepoint)
        {
            counterPos += 1;
            if (counterPos > 2)
            {
                counterPos = 0;
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
