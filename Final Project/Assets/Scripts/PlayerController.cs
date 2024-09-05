// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3.0f; // player movement speed
    private Vector2 _movement = new Vector2();  // player movement direction
    private Rigidbody2D _rb2d; // player rigidbody

    [SerializeField] private Animator _playerAnimator; // player animator
    [SerializeField] private int _lives = 3; // player amount of lives
    private string _lastDirection = "Front Left"; // default player direction (used for animation)
    [SerializeField] GameObject _playerShield; // shield spell

    private bool _allowTake = false; // if player is allowed to pick up an object
    private GameObject _nearItem; // if player is near an interactable object
    private string _nearItemName; // name of near interactable object

    // if player has spells + their grimoire
    private bool _hasGrimoire = false;
    private bool _hasShield = false;
    private bool _hasIgnite = false;
    private bool _isNearTorch = false;
    private GameObject _nearTorch; // if player is near torch
    private string _lastSpell;
    private int _numOfTorchesLit = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerShield.SetActive(false); // set shield to inactive
        
        // save data
        _lives = MainManager.SharedInstance.Lives;
        _hasGrimoire = MainManager.SharedInstance.HasGrimoire;
        _hasShield = MainManager.SharedInstance.HasShield;
        _hasIgnite = MainManager.SharedInstance.HasIgnite;
        _lastSpell = MainManager.SharedInstance.LastSpell;

        // debugging purposes
        print(_hasGrimoire);
        print(_hasShield);
        print(_hasIgnite);

    }

    void FixedUpdate() { // move velocity
        print("lives " + _lives);
        print("grimoire " + _hasGrimoire);
        print("ignite " + _hasIgnite);
        print("shield " + _hasShield);
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
        _movement.Normalize();
        _rb2d.velocity = _movement * _movementSpeed;

        // animation..determines where the player is heading, and what animation to play
        if (_movement.x > 0) {
            _playerAnimator.SetBool("idle", false);
            _playerAnimator.SetFloat("movementX", 1);
            _lastDirection = "Front Right";
            if (_movement.y > 0) {
                _playerAnimator.SetFloat("movementX", 1);
                _playerAnimator.SetFloat("movementY", 1);
                _lastDirection = "Back Right";
                
            }

            if (_movement.y < 0) {
                _playerAnimator.SetFloat("movementX", 1);
                _playerAnimator.SetFloat("movementY", -1);
                _lastDirection = "Front Right";
            }
        } 

        if (_movement.x < 0) {
            _playerAnimator.SetBool("idle", false);
            _playerAnimator.SetFloat("movementX", -1);
            _lastDirection = "Front Left";
            if (_movement.y > 0) {
                _playerAnimator.SetFloat("movementX", -1);
                _playerAnimator.SetFloat("movementY", 1);
                _lastDirection = "Back Left";
            }

            if (_movement.y < 0) {
                _playerAnimator.SetFloat("movementX", -1);
                _playerAnimator.SetFloat("movementY", -1);
                _lastDirection = "Front Left";
            }

        }

        if (_movement.y > 0) {
            _playerAnimator.SetBool("idle", false);
            _playerAnimator.SetFloat("movementY", 1);
            _lastDirection = "Back Left";
        }

        if (_movement.y < 0) {
            _playerAnimator.SetBool("idle", false);
            _playerAnimator.SetFloat(name: "movementY", -1);
            _lastDirection = "Front Left";
        }

        // idle animation
        if (_movement.x == 0 && _movement.y == 0 ) {
            _playerAnimator.SetBool("idle", true);
            switch (_lastDirection)
            {
                case "Back Right": 
                    _playerAnimator.SetInteger("direction", 1);
                    break;

                case "Front Right": 
                    _playerAnimator.SetInteger("direction", 2);
                    break;

                case "Front Left": 
                    _playerAnimator.SetInteger("direction", 3);
                    break;

                case "Back Left": 
                    _playerAnimator.SetInteger("direction", 4);
                    break;
            }
        }

        // if player has shield, player can shield themselves and be invulnerable to arrows
        if (Input.GetKeyDown(KeyCode.Q) && _hasShield && _lastSpell.Equals("Shield")) {
            _playerShield.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("SetPlayerShieldInactive", 3);
        }

        // if player has ignite, and is near a torch, player can ignite the torch (supposedly)
        if (Input.GetKeyDown(KeyCode.Q) && _hasIgnite && _isNearTorch && _lastSpell.Equals("Ignite")) {
            _nearTorch.GetComponent<TorchBehaviour>().LightTorch();
            // _nearTorch.GetComponentInChildren<Animator>().Play("StartFlameEffect");
            // _nearTorch = null;
        }

        // if player is allowed to take the item, player will take the item
        if (_allowTake && Input.GetKeyDown(KeyCode.E)) {
            _nearItem.GetComponent<InteractivesBehaviour>().UpdateCanvas(_nearItemName);
            _nearItem.SetActive(false);

            if (_nearItem.name == "Grimoire") {
                _hasGrimoire = true;
            }

            if (_nearItem.name == "Shield" && _hasGrimoire) {
                _hasShield = true;
                _lastSpell = "Shield";
            }

            if (_nearItem.name == "Ignite" && _hasShield && _hasGrimoire) {
                _hasIgnite = true;
                _lastSpell = "Ignite";
            }
        }

        // if player has spells in their grimoire
        if (_hasGrimoire && (_hasShield || _hasIgnite)) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                _lastSpell = "Shield";

            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                _lastSpell = "Ignite";
                
            }

            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().UpdateCanvas(_lastSpell);
        }
    

    }

    void OnTriggerEnter2D(Collider2D collider) {
        // damages player
        if (collider.tag == "Arrow" || collider.tag == "Boulder" && GetComponent<BoxCollider2D>().isActiveAndEnabled) {
            _lives--;
            GameObject.Find("GameManager").GetComponent<GameManager>().Lives(_lives);
            StartCoroutine("DamageCoroutine");
            
        }

        // if player is near any grimoire related objects
        if (collider.tag == "Grimoire") {
            _allowTake = true;
            _nearItem = collider.gameObject;
            _nearItemName = collider.name;
        }

        // if player is near a torch
        if (collider.tag == "Torch") {
            _isNearTorch = true;
            _nearTorch = collider.gameObject;
            _numOfTorchesLit++;

            if (_numOfTorchesLit == 3) {
                GameObject.Find("BoulderWall").SetActive(false);
            }
        }

    }

    // set player shield to inactive
    void SetPlayerShieldInactive() {
        _playerShield.GetComponent<ShieldBehaviour>().SetShieldInactive();
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // when player gets damaged
    IEnumerator DamageCoroutine() {
        _playerAnimator.Play("playerDamaged");
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);

        GetComponent<BoxCollider2D>().enabled = true;
    }

    // get amount of lives
    public int GetLives() {
        return _lives;
    }

    // save data
    public void SavePlayer() {
        MainManager.SharedInstance.Lives = _lives;
        MainManager.SharedInstance.HasGrimoire = _hasGrimoire;
        MainManager.SharedInstance.HasShield = _hasShield;
        MainManager.SharedInstance.HasIgnite = _hasIgnite;
        MainManager.SharedInstance.LastSpell = _lastSpell;
    }
    


}
