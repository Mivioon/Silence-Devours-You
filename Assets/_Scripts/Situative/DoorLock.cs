using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] BoxCollider2D _box;
    [SerializeField] GameObject _light1;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audioScream;
    [SerializeField] AudioSource _audioUpLightl;
    [SerializeField] GameObject _scaryStuff;

    private bool _isOk;
 
    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && PhotoPickUp._isScan == true && _isOk == false){
            _box.enabled = false;
            _light1.SetActive(false);
            _audio.Play();
            _isOk = true;
            StartCoroutine("NormalMode");
            _scaryStuff.SetActive(true);
        }
    }

    IEnumerator NormalMode(){
        yield return new WaitForSeconds(23);
        _light1.SetActive(true);
        _box.enabled = true;
        _audioUpLightl.Play();
    }
}
