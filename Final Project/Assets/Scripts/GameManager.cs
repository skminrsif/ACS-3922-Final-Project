// Djaleen Malabonga
// Student #3128901

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvasManager; // canvas manager
    [SerializeField] private List<GameObject> _spells; // list of spells (currently obsolute, due to bad planning)
    [SerializeField] private GameObject _player; // player 
    [SerializeField] private GameObject _nextScene; // next scene trigger object
    [SerializeField] private int _level = 0; // current level
    private int _health = 3; // player hp 

    // updates player's amount of lives
    public void Lives(int lives) {
        _canvasManager.GetComponent<CanvasManager>().ChangeLives(lives);
        
        // destroys player when player reaches no lives
        if (lives <= 0) {
            Destroy(_player);
        }
    }
    
    
}
