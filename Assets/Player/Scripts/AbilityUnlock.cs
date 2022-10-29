using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();

        if (player != null)
        {
            player.abilityUsage = true;
            Destroy(gameObject);
        }
    }
}
