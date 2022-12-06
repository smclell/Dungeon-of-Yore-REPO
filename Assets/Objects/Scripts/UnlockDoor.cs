using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnlockDoor : MonoBehaviour
{
    public NavMeshSurface Surface2D;
    public int unlockPos;

    private void Awake() {
        Surface2D.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Unlocks player = hitInfo.GetComponent<Unlocks>();

        if (player != null && (bool)player.unlocks[unlockPos])
        {
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
            Destroy(gameObject);
        }
    }
}
