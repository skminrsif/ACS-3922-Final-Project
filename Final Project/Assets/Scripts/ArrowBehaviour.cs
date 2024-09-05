// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private float _speed = 0;  // default speed
    private SpawnerData.SpawnDirection _direction; // direction of arrow

    void Start() {
        if (_direction == SpawnerData.SpawnDirection.Left) {
            Vector3 arrowScale = transform.localScale; // get scale of arrow sprite
            arrowScale.x = arrowScale.x * -1; // flip it horizontally
            transform.localScale = arrowScale; // set it as the current scale
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (_direction) // if arrow is going left or right
        {
            case SpawnerData.SpawnDirection.Left : // arrow going left
                _speed = -6.5f; // speed of arrow
                break;
            
            case SpawnerData.SpawnDirection.Right : // arrow going right
                _speed = 6.5f; // speed of arrow
                break;
                
        }
        
        transform.Translate(_speed * Time.deltaTime, 0, 0); // translate arrow speed to velocity
        
        switch (_direction)
        {
            case SpawnerData.SpawnDirection.Left : // if arrow firing to the left
                if (transform.position.x < -30) { // if out of bounds
                    Destroy(gameObject); // destroy arrow
                }
                break;
            
            case SpawnerData.SpawnDirection.Right : // if arrow firing to the right
                if (transform.position.x > 30) { // if out of bounds
                    Destroy(gameObject); // destroy arrow

                }
                break;
                
        }

    }

    // set direction of arrow spawn
    public void SetDirection(string direction) {
        if (direction == "left") {
            _direction = SpawnerData.SpawnDirection.Left;

        } else if (direction == "right") {
            _direction = SpawnerData.SpawnDirection.Right;

        }
    }

    // destroy arrow
    public void DestroyArrow() {
        Destroy(gameObject);
    }
}
