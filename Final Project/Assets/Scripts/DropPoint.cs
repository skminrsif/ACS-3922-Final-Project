// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    [SerializeField] public GameObject assignedBoulder; // assigned boulder for this drop point

    // assigns a drop point to a boulder
    public void AssignBoulder(GameObject boulder) {
        assignedBoulder = boulder;
    }

    // when the boulder collides with its assigned drop point
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == assignedBoulder) {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; // freezes the boulder's x, y, z
            
        }
    }

    
}
