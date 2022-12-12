using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButtons : MonoBehaviour
{
    //return to main menu with button press
    public void ReturnToMain() {
        SceneManager.LoadScene("Main Menu");
    }
}
