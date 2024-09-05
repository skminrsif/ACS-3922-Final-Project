// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {   // if player presses any letter from the word "pain", load the game
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.N)) {
            SceneManager.LoadScene(1);
        }
    }
}
