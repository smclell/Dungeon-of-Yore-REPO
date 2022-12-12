using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public int unlockPos;

    //unlock corresponding ability/key
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Unlocks player = hitInfo.GetComponent<Unlocks>();

        if (player != null)
        {
            player.unlocks[unlockPos] = true;
            Destroy(gameObject);
        }
    }
}
