using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnbledTask : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] AudioSource _audioOpen;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            _panel.SetActive(true);
            _audioOpen.Play();
        }
        if (Input.GetKeyUp(KeyCode.E)){
            _panel.SetActive(false);
        }
    }
}
