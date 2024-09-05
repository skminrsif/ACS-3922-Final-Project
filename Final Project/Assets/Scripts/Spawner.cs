// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn; // prefab to spawn
    [SerializeField] private float _repeatInterval; // repeat interval for spawning
    [SerializeField] private SpawnerData spawnerData; // spawner data

    void FixedUpdate() {
        Vector2 direction = Vector2.down; // default direction
        
        switch (spawnerData.Type) {// depending on the spawner type
            case SpawnerData.SpawnerType.Arrow:  // if arrow spawner
                switch (spawnerData.Direction) // direction
                {
                    case SpawnerData.SpawnDirection.Left: // fire arrows to the left
                        direction = Vector2.left;
                        break;

                    case SpawnerData.SpawnDirection.Right: // fire arrows to the right
                        direction = Vector2.right;
                        break;

                }
                break;

            case SpawnerData.SpawnerType.Boulder: // if boulder spawner
                direction = Vector2.down; // just rain down boulders on the player
                break;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction); // raycast from the spawner position to the direction of where its firing
        if (hit.collider != null) { 
            if (hit.collider.tag == "Player") { // if it hits a player
                Vector2 contact = hit.point; // get the contact point
                switch (spawnerData.Type)
                {
                    case SpawnerData.SpawnerType.Boulder : // spawn drop points to drop a boulder on the player
                        StartCoroutine(BoulderSpawnCoroutine(contact)); 
                        break;
                    
                    case SpawnerData.SpawnerType.Arrow : // spawn arrows from position firing at the player
                        StartCoroutine(ArrowSpawnCoroutine(direction));
                        break;
                }

        }

        }
        
        
    }

    // coroutine for spawning arrows
    IEnumerator ArrowSpawnCoroutine(Vector2 direction) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction); // raycast to detect if there is an arrow that has already been fired (to avoid arrow spawn spam)
        if (hit.collider.tag == "Arrow") {
            yield return new WaitForSeconds(_repeatInterval); // wait for how many seconds
        }
        GameObject arrow = SpawnObject(); // spawn arrow

        switch (spawnerData.Direction) // depends on the direction, fire arrow at that direction
        {
            case SpawnerData.SpawnDirection.Left:
                arrow.GetComponent<ArrowBehaviour>().SetDirection("left");
                break;

            case SpawnerData.SpawnDirection.Right:
                arrow.GetComponent<ArrowBehaviour>().SetDirection(direction: "right");
                break;

        }

    }

    // boulder spawn coroutine
    IEnumerator BoulderSpawnCoroutine(Vector2 contact) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down); // raycast to determine if drop point has already been instantiated
        if (hit.collider.tag == "DropPoint") {
            yield break;

        } 

        GameObject dropPoint = SpawnDropPoint(contact); // spawn drop point at player location

        GameObject boulder = SpawnObject(); // drop a boulder for funsies
        dropPoint.GetComponent<DropPoint>().AssignBoulder(boulder); // assign boulder to drop point
       

        yield return new WaitForSeconds(2); // wait for 2 seconds to destroy the drop point (to just make sure the boulder actually drops right, and stops at where the drop point is at)
        

        Destroy(dropPoint);

        yield return new WaitForSeconds(1.5f); // wait for 1.5 seconds to destroy boulder (goodbye screen clutter)

        Destroy(boulder);
        
        
    }

    // spawns a boulder drop point at player position
    GameObject SpawnDropPoint(Vector2 contact) {
        GameObject dropPoint = Instantiate(spawnerData.DropPoint, contact, Quaternion.identity);
        return dropPoint;

    }


    // spawns the assigned prefab
    public GameObject SpawnObject() {
        if (_prefabToSpawn != null) { 
            return Instantiate(_prefabToSpawn, transform); // keep spawning stuff

        }

        return null;
    }

    // debugging purposes
    // void OnDrawGizmos() {
    //     switch (spawnerData.Direction) {
    //         case SpawnerData.SpawnDirection.Left :
    //             Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 10);
    //             break;
            
    //         case SpawnerData.SpawnDirection.Right :
    //             Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 10);
    //             break;

    //         case SpawnerData.SpawnDirection.Down :
    //             Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10);
    //             break;
    //     }
        
    // }
}
