using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BreakAbilityWall : MonoBehaviour
{
    private int abilityBreak;

    private void Start() {
        //set which ability will break wall
        switch (gameObject.name) {
            case string a when a.Contains("Ice Wall"):
                abilityBreak = 1;
                break;
            case string a when a.Contains("Rock Wall"):
                abilityBreak = 2;
                break;

        }
    }

    //break wall based on collided entity
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        string name = hitInfo.name;
        switch (abilityBreak) {
            case 1:
                if (name.Contains("Fireball"))
                    Destroy(gameObject);
                break;
            case 2:
                if (name.Contains("Ground Slam Attack"))
                    Destroy(gameObject);
                break;
            default:
                Debug.Log("Invalid interact");
                break;
        }
    }
}
