using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUdochka : MonoBehaviour
{
    [SerializeField] Transform _trand;
    [SerializeField] BoxCollider2D _box;
    [SerializeField] Animator _anim;

    [SerializeField] SpriteRenderer _sprRed;
    [SerializeField] Sprite _spr;

    [SerializeField] AudioSource _pick;
    [SerializeField] AudioSource _lovla;
    [SerializeField] AudioSource _during;

    [SerializeField] GameObject _obl;
    [SerializeField] GameObject _objj;

    public static bool _isFishing;

    private bool _isPick;

    private void Update(){
        if (_isPick == true){
            transform.position = _trand.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BenzolPickUp._isLiting == true && _isPick == false){
            _isPick = true;
            _pick.Play();
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _anim.SetTrigger("Loading");
            _box.isTrigger = true;
        }
        if (_coll.gameObject.CompareTag("F") && _isPick == true && _isFishing == false){
            _anim.SetTrigger("Loading");
            _lovla.Play();
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _obl.SetActive(true);
            _sprRed.sprite = _spr;
            _isFishing = true;
        }
        if (_coll.gameObject.CompareTag("Plita") && _isPick == true && _isFishing == true && FrizenWork._isFrizen == false){
            _anim.SetTrigger("Loading");
            FrizenWork._isFrizen = true;
            _objj.SetActive(true);
            _during.Play();
            gameObject.SetActive(false);
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
