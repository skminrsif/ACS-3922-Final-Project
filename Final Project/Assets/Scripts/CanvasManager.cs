// Djaleen Malabonga
// Student #3128901

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas _gameTextCanvas; // canvas game hints
    [SerializeField] private Canvas _gameOverlayCanvas; // canvas for game overlay
    [SerializeField] private Text _livesText; // lives
    [SerializeField] private Text _grimoireText; // grimoire hint
    [SerializeField] private Text _shieldText; // shield hint
    [SerializeField] private Text _igniteText; // ignite hint
    [SerializeField] private GameObject _grimoireSpellSlot; // grimoire spell slot
    [SerializeField] private GameObject _spellSlot; // spell slot 
    [SerializeField] private Sprite _shieldSprite; // shield sprite
    [SerializeField] private Sprite _igniteSprite; // ignite sprite
    
    // if player has unlocked these spells + grimoire
    private bool _hasGrimoire = false;
    private bool _hasIgnite = false;
    private bool _hasShield = false;
    private string _lastSpell;


    void Start() {
        // // save data (doesn't work)
        _hasGrimoire = MainManager.SharedInstance.HasGrimoire;
        _hasShield = MainManager.SharedInstance.HasShield;
        _hasIgnite = MainManager.SharedInstance.HasIgnite;
        _lastSpell = MainManager.SharedInstance.LastSpell;

        // remaining lives
        _livesText.text = "Remaining Lives: " + GameObject.Find("Player").GetComponent<PlayerController>().GetLives(); 
        // set most ui element to false
        _grimoireText.gameObject.SetActive(false);
        _shieldText.gameObject.SetActive(false);
        _igniteText.gameObject.SetActive(false);
        // _grimoireSpellSlot.SetActive(false);
        // _spellSlot.SetActive(false);

        // if the player has their grimoire unlocked, grimoire element in canvas is shown
        if (_hasGrimoire) {
            _grimoireSpellSlot.SetActive(true);

        } else {
            _grimoireSpellSlot.SetActive(false);
        }

        // if the player has their spells unlocked, spells element in canvas is shown
        if (_hasIgnite || _hasShield) {
            _spellSlot.SetActive(true);

            if (_hasShield) {
                _spellSlot.GetComponent<Image>().sprite = _shieldSprite;
            }
        
        } else {
            _spellSlot.SetActive(false);
        } 

        // debugging purposes
        // print(_hasGrimoire);
        // print(_hasShield);
        // print(_hasIgnite);

        
    }

    // set hint text to active
    public void SetTextActive(string textName) {
        switch (textName) {
            case "Grimoire" :
                _grimoireText.gameObject.SetActive(true);
                break;
            
            case "Shield" :
                _shieldText.gameObject.SetActive(true);
                break;
            
            case "Ignite" :
                _igniteText.gameObject.SetActive(true);
                break;
        }
        
    }

    // set hint text to inactive
    public void SetTextInactive(string textName) {
        switch (textName) {
            case "Grimoire" :
                _grimoireText.gameObject.SetActive(false);
                break;

            case "Shield" :
                _shieldText.gameObject.SetActive(false);
                break;

            case "Ignite" :
                _igniteText.gameObject.SetActive(false);
                break;
        }
        
    }

    // change the amount of lives on canvas
    public void ChangeLives(int amount) {
        _livesText.text = "Lives Remaining: " + amount;
    }

    // update the canvas when items get unlocked
    public void UpdateCanvas(string updateItem) {
        switch (updateItem)
        {
            case "Grimoire" :
                _hasGrimoire = true;
                _grimoireSpellSlot.SetActive(true);
                break;

            case "Shield" :
                _hasShield = true;
                _spellSlot.SetActive(true);
                _spellSlot.GetComponent<Image>().sprite = _shieldSprite;
                _lastSpell = "Shield";
                break;

            case "Ignite" :
                _hasIgnite = true;
                _spellSlot.GetComponent<Image>().sprite = _igniteSprite;
                _lastSpell = "Ignite";
                break;
            
        }
    }

    // // save data method
    // public void SaveCanvas() {
    //     MainManager.SharedInstance.LastSpell = _lastSpell;
    // }

}
