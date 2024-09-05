// Djaleen Malabonga
// Student #3128901

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb2d; // boulder rigidbody
    [SerializeField] private GameObject _assignedDropPoint; // assigned drop point
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>(); // initializing rigidbody
        
        
    }

    // assigns boulder to a drop point
    public void AssignDropPoint(GameObject dropPoint) {
        _assignedDropPoint = dropPoint;

    }


    // debugging purposes
    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "Player") {
    //         print("player");
    //     }


    // }

    // debugging purposes
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Vector3 direction = transform.TransformDirection(-Vector3.up) * 5;
    //     Gizmos.DrawRay(transform.position, direction);
    // }
}
