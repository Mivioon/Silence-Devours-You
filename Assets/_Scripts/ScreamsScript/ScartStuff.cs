using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class ScartStuff : MonoBehaviour
{
    [SerializeField] private bool _isColling;
    [SerializeField] PostProcessVolume _volumPost;
    [SerializeField] PostProcessProfile _profie;

    [SerializeField] Animator _anim;
    [SerializeField] Animator _anim2;
    [SerializeField] Animator _anim3;

    [SerializeField] AudioSource _ausio;
    [SerializeField] AudioSource _audiooJUMP;

    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && _isColling == false && BenzolPickUp._isLiting == true){
            _audiooJUMP.Play();
            _isColling = true;
            _sprR.sprite = _spr;
            _anim3.SetBool("Ju", true);
            StartCoroutine("SpeedStop");
            _volumPost.profile = _profie;
            _ausio.Play();
            _anim.SetTrigger("Scary");
            _anim2.SetBool("Bu", true);
            ControlPlayer._speed = 0f;
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(12);
        _anim.SetTrigger("Downi");
        StartCoroutine("Load");
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(8);
    }
}
