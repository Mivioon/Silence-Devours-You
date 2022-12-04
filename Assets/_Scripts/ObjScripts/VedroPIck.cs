using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VedroPIck : MonoBehaviour
{
    [SerializeField] Animator _anim;

    [SerializeField] AudioSource _audio;

    [SerializeField] GameObject _metla;

    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;
    [SerializeField] Sprite _sprDefault;

    private void Update(){
        if (MootWash._isWash == true){
            _sprR.sprite = _sprDefault;
            _metla.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BockActive._isBocking == true && MootWash._isMetetUp == false){
            MootWash._isMetetUp = true;
            _sprR.sprite = _spr;
            _metla.SetActive(true);
            _audio.Play();
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _anim.SetTrigger("Loading");
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
