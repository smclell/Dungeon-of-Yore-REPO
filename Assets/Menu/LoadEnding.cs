using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;

    //setting win/lose screen properly
    private void Awake() {
        if (WinOrLose.win) {
            WinScreen.SetActive(true);
            LoseScreen.SetActive(false);
        }
        else {
            WinScreen.SetActive(false);
            LoseScreen.SetActive(true);
        }
    }
}
