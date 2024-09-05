// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBehaviour : MonoBehaviour
{
    [SerializeField] private string _nextLevel;

    // if player enters the trigger volume, load next level with save data
    void OnTriggerEnter2D(Collider2D collider) {
        collider.GetComponent<PlayerController>().SavePlayer();
        // GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SaveCanvas();
        SceneManager.LoadScene(_nextLevel);
    }
}
