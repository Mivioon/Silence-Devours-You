using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinifeHolder : MonoBehaviour
{
    public static float _hp;
    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;
    [SerializeField] Sprite _spr2;
    [SerializeField] Sprite _spr3;

    [Header("PlayerSettings")]
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;
    [SerializeField] Transform _point;
    [SerializeField] Transform _pointPlayer;

    private void Start(){
        _hp = 4f;
    }

    private void Update(){
        if (_hp == 3f){
            _sprR.sprite = _spr;
        }
        if (_hp == 2f){
            _sprR.sprite = _spr2;
        }
        if (_hp == 1f){
            _sprR.sprite = _spr3;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && _hp == 1f){
            _anim.SetTrigger("Loading");
            _audio.Play();
            _pointPlayer.transform.position = _point.transform.position;
            HPBar._hp = 100f;
        }
    }
}
