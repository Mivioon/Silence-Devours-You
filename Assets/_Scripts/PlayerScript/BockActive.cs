using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BockActive : MonoBehaviour
{
    public static bool _isBocking;

    [SerializeField] GameObject _obj;

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _bocking;

    private void Awake(){
        _isBocking = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Bock") && TymbaPoint._isStumb == true && _isBocking == false){
            _anim.SetTrigger("Loading");
            ControlPlayer._speed = 0f;
            _bocking.Play();
            _isBocking = true;
            StartCoroutine("SpeedStop");
            _obj.SetActive(true);
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    } 
}
