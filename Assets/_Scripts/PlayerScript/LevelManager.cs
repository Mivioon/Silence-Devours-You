using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AudioSource _sleep;
    [SerializeField] GameObject _obj;
    [SerializeField] private int _loadScene;
    public static int _loadyScene;
    [SerializeField] Animator _anim;

    private void Start(){
        _loadyScene = _loadScene;
        if (_loadScene < 5 || _loadScene > 5){
            MootWash._isWash = true;
        }
        ToiletPuxh._isClening = true;
        if (LevelManager._loadyScene == 5){
            ToiletPuxh._isClening = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Bed") && BockActive._isBocking == true && _loadScene <= 2){
            ControlPlayer._speed = 0f;
            _anim.SetTrigger("Downi");
            StartCoroutine("LEnding");
            _obj.SetActive(true);
            _sleep.Play();
        } else if (_coll.gameObject.CompareTag("Bed") && FrizenWork._isFrizen == true && _loadScene >= 3){
            ControlPlayer._speed = 0f;
            _anim.SetTrigger("Downi");
            StartCoroutine("LEnding");
            _obj.SetActive(true);
            _sleep.Play();
        }
    }

    IEnumerator LEnding(){
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(_loadScene);
    }
}
