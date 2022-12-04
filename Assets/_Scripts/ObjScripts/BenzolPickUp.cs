using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenzolPickUp : MonoBehaviour
{
    [SerializeField] private Transform _armPick;

    [SerializeField] GameObject _benzolFake;
    [SerializeField] GameObject _obj;

    [SerializeField] AudioSource _pickUp;
    [SerializeField] AudioSource _galiv;

    [SerializeField] BoxCollider2D _box;

    [SerializeField] Animator _anim;

    [SerializeField] private bool _isPick;
    public static bool _isLiting;

    private void Start(){
        _isLiting = false;
    }

    private void Update(){
        if (_isPick == true){
            gameObject.transform.position = _armPick.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && PhotoPickUp._isPhotography == true && _isPick == false){
            _isPick = true;
            _box.isTrigger = true;
            _pickUp.Play();
            ControlPlayer._speed = 0f;
            StartCoroutine("SpeedStop");
            _anim.SetTrigger("Loading");
        }
        if (_coll.gameObject.CompareTag("Motor") && _isPick == true && _isLiting == false){
            _isLiting = true;
            _isPick = false;
            _galiv.Play();
            _obj.SetActive(true);
            _benzolFake.SetActive(true);
            gameObject.SetActive(false);
            _anim.SetTrigger("Loading");
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}