using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (name.Contains("Ice Wall"))
            {
                Destroy(hitInfo.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
