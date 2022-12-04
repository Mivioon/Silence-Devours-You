using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorBuild : MonoBehaviour
{
    [SerializeField] GameObject _light1;
    [SerializeField] GameObject _light2;
    [SerializeField] GameObject _light3;

    [SerializeField] AudioSource _audio;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && OffLightOne._isOff1 == true){
            _light1.SetActive(true);
            _light2.SetActive(true);
            _light3.SetActive(true);

            _audio.Play();

            OffLightOne._isOff1 = false;
        }
    }
}
