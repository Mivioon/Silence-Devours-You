using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUo : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;

    [SerializeField] GameObject _pointPlayer;
    public static bool _isPIck;

    private void Awake(){
        _isPIck = false;
        _anim.SetTrigger("Loading");
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update(){
        if (_isPIck == true){
            gameObject.transform.position = _pointPlayer.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            _isPIck = true;
            _anim.SetTrigger("Loading");
            _audio.Play();
        }
    }
}
