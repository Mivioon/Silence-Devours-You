using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Worked : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audio2;
    [SerializeField] AudioSource _audio3;
    [SerializeField] PostProcessVolume _postVolum;
    [SerializeField] PostProcessProfile _profile;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            _anim.SetTrigger("Svet");
            _audio.Play();
            _audio2.Stop();
            _audio3.Stop();
            _postVolum.profile = _profile;
            AIGhost._speed = 0f;
            HPBar._minusHp = 0f;
            StartCoroutine("Load");
        }
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(6);
    }
}
