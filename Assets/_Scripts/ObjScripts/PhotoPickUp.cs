using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPickUp : MonoBehaviour
{
    [SerializeField] private Transform _arnPick;

    [SerializeField] private GameObject _photoFake;

    [SerializeField] Animator _anim;

    [SerializeField] GameObject _obj;
    [SerializeField] GameObject _Obj2;

    [SerializeField] SpriteRenderer _spr;
    [SerializeField] Sprite _spRR;

    public static bool _isPick;
    public static bool _isPhotography;
    public static bool _isScan;

    [SerializeField] private AudioSource _piciki;
    [SerializeField] private AudioSource _photo;
    [SerializeField] private AudioSource _scaning;

    private void Start(){
        _isPick = false;
        _isPhotography = false;
        _isScan = false;
    }

    private void Update(){
        if (_isPick == true){
            transform.position = _arnPick.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BockActive._isBocking == true && _isPick == false && MootWash._isWash == true){
            _isPick = true;
            _piciki.Play();
            _anim.SetTrigger("Loading");
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
        }
        if (_coll.gameObject.CompareTag("F") && _isPick == true && _isPhotography == false){
            _isPhotography = true;
            _spr.sprite = _spRR;
            _photo.Play();
            _anim.SetTrigger("Photo");
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _obj.SetActive(true);
        }
        if (_coll.gameObject.CompareTag("Stan") && _isPick == true && _isPhotography == true && _isScan == false){
            _isPick = false;
            _isScan = true;
            _photoFake.SetActive(true);
            _scaning.Play();
            _anim.SetTrigger("Loading");
            gameObject.SetActive(false);
            _Obj2.SetActive(true);
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
