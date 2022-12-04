using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OberegOpenUp : MonoBehaviour
{
    public static bool _isKilingLamb;
    public static bool _isOpened;

    [SerializeField] Transform _zeroPoint;

    [SerializeField] float _xOne;
    [SerializeField] float _xTwo;

    [SerializeField] float _yOne;
    [SerializeField] float _yTwo;

    [Header("Custom")]
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;

    [Header("Player")]
    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;

    private void Awake(){
        gameObject.transform.position = new Vector2(Random.Range(_xOne, _xTwo), Random.Range(_yOne, _yTwo));
        StartCoroutine("Randoming");
        _isKilingLamb = false;
        _isOpened = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && _isKilingLamb == true){
            _anim.SetTrigger("Loading");
            _audio.Play();
            _sprR.sprite = _spr;
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _isOpened = true;
            gameObject.transform.position = _zeroPoint.transform.position;
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    } 

    IEnumerator Randoming(){
        yield return new WaitForSeconds(25);
        gameObject.transform.position = new Vector2(Random.Range(_xOne, _xTwo), Random.Range(_yOne, _yTwo));
    }
}
