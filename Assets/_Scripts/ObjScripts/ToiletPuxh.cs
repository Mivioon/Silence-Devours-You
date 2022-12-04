using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPuxh : MonoBehaviour
{
    [SerializeField] Animator _anim;

    [SerializeField] ToiletSound _oi;

    [SerializeField] GameObject _blood;
    [SerializeField] GameObject _obj;

    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audio2;

    public static bool _isClening;
    [SerializeField] bool _isis;

    private void Start(){
        _isClening = true;
        if (LevelManager._loadyScene == 6){
            _isClening = false;
        }
        _isis = _isClening;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BenzolPickUp._isLiting == true && _isClening == false){
            _blood.SetActive(true);
            _audio.Play();
            _oi.enabled = false;
            _obj.SetActive(true);

            _isClening = true;

            StartCoroutine("Plaing");

            _anim.SetTrigger("Loading");
        }
    }

    IEnumerator Plaing(){
        yield return new WaitForSeconds(1.4f);
        _audio2.Play();
    }
}
