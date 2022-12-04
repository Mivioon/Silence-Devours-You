using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TymbaPoint : MonoBehaviour
{
    public static bool _isStumb = false;
    [SerializeField] bool _isStumbi;

    [SerializeField] Animator _anim;
    [SerializeField] GameObject _obj;

    [SerializeField] GameObject _pack;

    [SerializeField] AudioSource _packing;


    [SerializeField] Sprite _spr;
    [SerializeField] SpriteRenderer _sprR;

    private void Awake(){
        _isStumb = _isStumbi;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Tym") && _isStumb == false){
            _anim.SetTrigger("Loading");
            _pack.SetActive(false);
            _packing.Play();
            _isStumb = true;
            ControlPlayer._speed = 0f;
            _sprR.sprite = _spr;
            StartCoroutine("SpeedStop");
            _obj.SetActive(true);
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
