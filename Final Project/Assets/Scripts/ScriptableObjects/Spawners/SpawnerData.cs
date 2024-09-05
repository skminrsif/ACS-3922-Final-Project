// Djaleen Malabonga
// Student #3128901

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawner Scriptable Object
[CreateAssetMenu(fileName = "New SpawnerData", menuName = "SpawnerData", order = 51)]
public class SpawnerData : ScriptableObject
{
    // type of spawner
    public enum SpawnerType {
        Boulder, 
        Arrow
    }

    // what direction it spawns to
    public enum SpawnDirection {
        Left,
        Right,
        Down
    }

    [SerializeField] private SpawnerType _spawnerType; // type of spawner
    [SerializeField] private GameObject _objectToTrack; // tracks player (for boulder)
    [SerializeField] private GameObject _dropPoint; // drop point (for boulder)
    [SerializeField] private SpawnDirection _spawnDirection; // what direction it spawns to

    // getter for type of spawner
    public SpawnerType Type {
        get {
            return _spawnerType;
        }
    }

    // getter for the object that it tracks (for boulder)
    public GameObject ObjectToTrack {
        get {
            return _objectToTrack;
        }
    }

    // getter for drop point (for boulder)
    public GameObject DropPoint {
        get {
            return _dropPoint;
        }
    }

    // what direction it spawns to
    public SpawnDirection Direction {
        get {
            return _spawnDirection;
        }
    }

    
    
}
