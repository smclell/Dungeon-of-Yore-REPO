using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fireball : MonoBehaviour
{
    public int damage = 60;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        string name = hitInfo.name;
        if (!(name.Equals("PlayerCharacter") || name.Equals("Player Melee Attack")))
        {
            Destroy(gameObject);
        }
    }
}
