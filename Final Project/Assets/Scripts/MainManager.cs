using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    private int _lives = 3;
    private bool _hasGrimoire;
    private bool _hasIgnite;
    private bool _hasShield;
    private string _lastSpell;
    public static MainManager instance;

    // getters and setters

    public static MainManager SharedInstance {
        get {
            return instance;
        }
    }

    public string LastSpell {
        get {
            return _lastSpell;
        }

        set {
            _lastSpell = value;
        }
    }

    public int Lives {
        get {
            return _lives;
        } 
        
        set {
            _lives = value;
        }
    }

    public bool HasGrimoire {
        get {
            return _hasGrimoire;
        } 
        
        set {
            _hasGrimoire = value;
        }
    }

    public bool HasShield {
        get {
            return _hasShield;
        } 
        
        set {
            _hasShield = value;
        }
    }

    public bool HasIgnite {
        get {
            return _hasIgnite;
        } 
        
        set {
            _hasIgnite = value;
        }
    }


    private void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;

        } else if (instance != this) {
            Destroy(gameObject);
        }
    }
}
