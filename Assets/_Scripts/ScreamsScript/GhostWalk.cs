using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GhostWalk : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] private bool _isGo;

    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;

    [SerializeField] Transform _pontPlayer;
    [SerializeField] Transform _pont2;

    [SerializeField] GameObject _light; 

    private void  Start(){
        StartCoroutine("GO");
    }

    private void Update(){
        if (_isGo == true){
            transform.position = Vector2.MoveTowards(transform.position, _pontPlayer.transform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            _light.SetActive(true);
            _audio.Play();
            _anim.SetTrigger("Scary");
            StartCoroutine("SpeedStop");
            _pontPlayer = _pont2;
            ControlPlayer._speed = 0f;
        }
    }

    IEnumerator GO(){
        yield return new WaitForSeconds(3f);
        _isGo = true;
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(2);
        ControlPlayer._speed = 3f;
    }
} 
