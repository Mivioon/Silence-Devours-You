using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrizenWork : MonoBehaviour
{
    [SerializeField] GameObject _terla;
    [SerializeField] Transform _armPick;

    [SerializeField] Animator _anim;

    [SerializeField] AudioSource _frizened;

    [SerializeField] private bool _isPick;
    public static bool _isFrizen;

    private void Start(){
        _isFrizen = false;
        _terla.SetActive(false);
    }

    private void Update(){
        _terla.transform.position = _armPick.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BenzolPickUp._isLiting == true && _isFrizen == false && _isPick == false && ToiletPuxh._isClening == true){
            _isPick = true;
            _terla.SetActive(true);
            _frizened.Play();
            _anim.SetTrigger("Loading");
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
        }
    } 

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
