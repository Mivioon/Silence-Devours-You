using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBatPlayer : MonoBehaviour
{
    public static float _hp;
    [SerializeField] Animator _anim;
    [SerializeField] Animator _anim2;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _embient;
    [SerializeField] AudioSource _embient2;
    [SerializeField] AudioSource _shakeBlood;
    [SerializeField] GameObject _darking;

    private void Awake(){
        _hp = 2f;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Ghost")){
            _anim.SetTrigger("Loading");
            _anim2.SetBool("Bu", true);
            _audio.Play();
            _shakeBlood.Play();
            HPBar._minusHp = 2.5f;
            HPBar._hp -= 30f;
            _hp -= 1f;
            StartCoroutine("Normal");
            if(_hp <= 0f){
                _darking.SetActive(true);
                ControlPlayer._speed = 0f;
                _embient.Stop();
                _embient2.Stop();
                _audio.Stop();
                StartCoroutine("Loady");
            }
        }
    }

    IEnumerator Loady(){
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(5);
    }

    IEnumerator Normal(){
        yield return new WaitForSeconds(20);
        HPBar._minusHp = 2f;
        _audio.Stop();
        _anim2.SetBool("Bu", false);
    }
}
