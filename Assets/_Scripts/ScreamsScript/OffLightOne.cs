using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLightOne : MonoBehaviour
{
    [SerializeField] GameObject _light1;
    [SerializeField] GameObject _light2;
    [SerializeField] GameObject _light3;

    [SerializeField] BoxCollider2D _box;

    [SerializeField] Transform _point;

    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audio2;

    public static bool _isOff1;

    private void Start(){
        _isOff1 = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && _isOff1 == false && BockActive._isBocking == true && PhotoPickUp._isScan == false){
            _light1.SetActive(false);
            _light2.SetActive(false);
            _light3.SetActive(false);

            _box.enabled = false;

            gameObject.transform.position = _point.transform.position;

            _audio.Play();

            _isOff1 = true;
        }
        if (_coll.gameObject.CompareTag("Player") && _isOff1 == false && BockActive._isBocking == true && PhotoPickUp._isScan == true && FrizenWork._isFrizen == true){
            _light1.SetActive(false);
            _light2.SetActive(false);
            _light3.SetActive(false);

            gameObject.transform.position = _point.transform.position;

            _audio.Play();
            StartCoroutine("Time");

            _isOff1 = true;
        }
    }

    IEnumerator Time(){
        yield return new WaitForSeconds(0.3f);
        _audio2.Play();
    }
}
