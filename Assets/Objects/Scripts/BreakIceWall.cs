using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BreakIceWall : MonoBehaviour
{
    public NavMeshSurface Surface2D;
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        string name = hitInfo.name;
        if (name.Contains("Fireball")) {
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
            Destroy(gameObject);
        }
    }
}
