using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsOkay : MonoBehaviour
{
    [SerializeField] AudioSource _audio;

    private void Start(){
        _audio.Play();
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Action") || _coll.gameObject.CompareTag("ActiOn") || _coll.gameObject.CompareTag("ActiON")){
            if (ActionPlay._isOuty == true){
                _audio.Play();
            }
            if (ActionPlay._isOuty == false){
                _audio.Stop();
            }
        }
    }
}
