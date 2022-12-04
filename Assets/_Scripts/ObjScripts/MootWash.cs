using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MootWash : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _clip;
    [SerializeField] Animator _anim;

    [SerializeField] GameObject _obj;

    public static bool _isMetetUp;
    public static bool _isWash;
    public static float _cleaning;

    private void Awake(){
        _isMetetUp = false;
        _cleaning = 0f;
    }

    private void Update(){
        if (_cleaning >= 5f){
            _isWash = true;
            _obj.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && _isMetetUp == true && BockActive._isBocking == true){
            _cleaning += 1f;
            _audio.PlayOneShot(_clip);
            Destroy(gameObject);
        }
        if (_coll.gameObject.CompareTag("Player") && _cleaning > 0f){
            _anim.SetTrigger("Loading");
        }
    }
}
