// Djaleen Malabonga
// Student #3128901
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
    private GameObject _torchLight;
    void Start() {
        _torchLight = gameObject.transform.GetChild(0).gameObject;
        _torchLight.SetActive(false);
    }

    public void LightTorch() {
        _torchLight.SetActive(true);
    }
     
}
