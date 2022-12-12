using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount;

    //heal player by amount 
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null) {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
