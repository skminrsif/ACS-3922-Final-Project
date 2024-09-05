// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivesBehaviour : MonoBehaviour
{
    [SerializeField] private SpellData _spellData; // spell data
    
    // when player is near an interactive object, show its hint text
    void OnTriggerEnter2D(Collider2D collider) {
        if (this._spellData.Type == SpellData.SpellType.Grimoire && collider.tag == "Player") {
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextActive("Grimoire");
        }

        if (this._spellData.Type == SpellData.SpellType.Shield  && collider.tag == "Player") {
            print("wah");
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextActive("Shield");
        }

        if (this._spellData.Type == SpellData.SpellType.Ignite  && collider.tag == "Player") {
            print("wah");
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextActive("Ignite");
        }


        
    }

    // when player goes away from an interactive object, hide its hint text
    void OnTriggerExit2D(Collider2D collider) {
        if (this._spellData.Type == SpellData.SpellType.Grimoire  && collider.tag == "Player") {
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextInactive("Grimoire");
        }

        if (this._spellData.Type == SpellData.SpellType.Shield  && collider.tag == "Player") {
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextInactive("Shield");
        }

        if (this._spellData.Type == SpellData.SpellType.Ignite  && collider.tag == "Player") {
            GameObject.Find("CanvasManager").GetComponent<CanvasManager>().SetTextInactive("Ignite");
        }

    }

    // update canvas 
    public void UpdateCanvas(string updateItem) {
        GameObject.Find("CanvasManager").GetComponent<CanvasManager>().UpdateCanvas(updateItem);
    }
}
