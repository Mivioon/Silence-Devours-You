using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltarWork : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _obj;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && TakePoop._isFind == true){
            _anim.SetTrigger("Svet");
            _obj.SetActive(true);
            ControlPlayer._speed = 0f;
            _audio.Play();
            StartCoroutine("Load");
        }
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(7);
    }
}
