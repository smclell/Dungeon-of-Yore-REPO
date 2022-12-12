using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public int unlockPos;

    //end game when player interacts with door and has the final key
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Unlocks player = hitInfo.GetComponent<Unlocks>();

        if (player != null && (bool)player.unlocks[unlockPos]) {
            WinOrLose.EndCondition(true);
            SceneManager.LoadScene("WinOrLose");
        }
    }
}
