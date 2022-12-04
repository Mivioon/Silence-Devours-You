using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDay1 : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;
    [SerializeField] AudioSource _audio;

    private void Start(){
        _anim.SetTrigger("Loading");
    }

    public void LoadDay(){
        _sprR.sprite = _spr;
        _audio.Play();
        _anim.SetTrigger("Downi");
        StartCoroutine("load");
    }

    IEnumerator  load(){
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }                                                                                                                                   
}
