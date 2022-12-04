using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingThings : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _obj;
    [SerializeField] GameObject _obj2;
    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;
    [SerializeField] Animator _anim;

    public static bool _isPacksl;

    private void Start(){
        _isPacksl = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BockActive._isBocking == true && _isPacksl == false){
            _audio.Play();
            _obj2.SetActive(true);
            _isPacksl = true;            
            _sprR.sprite = _spr;
            _obj.SetActive(true);
            _anim.SetTrigger("Loading");
        }
    }
}
