using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnlockDoor : MonoBehaviour
{
    public int unlockPos;

    //unlock/destroy door if player has the key
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Unlocks player = hitInfo.GetComponent<Unlocks>();

        if (player != null && (bool)player.unlocks[unlockPos])
        {
            Destroy(gameObject);
        }
    }
}
