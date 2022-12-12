using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //start game button
    public void PlayGame() {
        SceneManager.LoadScene("Level 1");
    }

    //Quit game button
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
