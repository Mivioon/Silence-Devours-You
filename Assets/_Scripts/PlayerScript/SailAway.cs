using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SailAway : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _obj;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && PackingThings._isPacksl == true){
            _anim.SetTrigger("Downi");
            _obj.SetActive(true);
            _audio.Play();
            ControlPlayer._speed = 0f;
            StartCoroutine("DD");
        }
    }

    IEnumerator DD(){
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(9);
    }
}
