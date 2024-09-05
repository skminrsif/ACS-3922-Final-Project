// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField] Animator _shieldAnimator; // shield animation

    void Awake() {
        _shieldAnimator.Play("shield"); // play shield animation on awake
    }

    // IEnumerator ShieldCoroutine() {
    //     _shieldAnimator.Play("shield");
    //     yield return new WaitForSeconds(5);
    //     gameObject.SetActive(false);
    //     yield break;
    // }

    // when arrow goes near the shield, it should destroy the arrow
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Arrow") {
            collider.GetComponent<ArrowBehaviour>().DestroyArrow();
        }
    }

    // sets the shield to inactive
    public void SetShieldInactive() {
        gameObject.SetActive(false);
    }
}
