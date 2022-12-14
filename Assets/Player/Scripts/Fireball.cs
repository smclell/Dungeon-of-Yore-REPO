using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fireball : MonoBehaviour
{
    public int damage = 60;
    //deal damage to target entity unless hit wall 
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        string name = hitInfo.name;
        if (!(name.Equals("PlayerCharacter") || name.Equals("Player Melee Attack") || name.Contains("Heart Pickup")))
        {
            Destroy(gameObject);
        }
    }
}
