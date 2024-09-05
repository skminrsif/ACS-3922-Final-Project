// Djaleen Malabonga
// Student #3128901

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spell Data Scriptable Object
[CreateAssetMenu(fileName = "New SpellData", menuName = "SpellData", order = 52)]
public class SpellData : ScriptableObject
{
    // spell type
    public enum SpellType {
        Grimoire,
        Shield,
        Ignite
    }

    [SerializeField] private SpellType _spellType; // spell type

    // getter for spell type
    public SpellType Type {
        get {
            return _spellType;
        }
    }

    
    
}
