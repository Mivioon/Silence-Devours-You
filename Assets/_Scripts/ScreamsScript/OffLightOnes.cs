using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLightOnes : MonoBehaviour
{
    [SerializeField] GameObject _light1;
    [SerializeField] GameObject _light2;
    [SerializeField] GameObject _light3;

    [SerializeField] BoxCollider2D _box;

    [SerializeField] Animator _anim;

    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audio2;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && OffLightOne._isOff1 == true){
            _light1.SetActive(true);
            _light2.SetActive(true);
            _light3.SetActive(true);

            _box.enabled = true;

            OffLightOne._isOff1 = false;

            StartCoroutine("SpeedStop");
            ControlPlayer._speed = 0f;

            _anim.SetTrigger("Loading");

            _audio.Play();
            _audio2.Play(); 
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    } 
}
