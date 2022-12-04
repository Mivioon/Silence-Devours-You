using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarelkaWorked : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _obj;

    [SerializeField] AudioSource _trizened;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Chair")){
            _trizened.Play();
            _obj.SetActive(true);
            _anim.SetTrigger("Loading");
            FrizenWork._isFrizen = true;
            gameObject.SetActive(false);
        }
    }
}
