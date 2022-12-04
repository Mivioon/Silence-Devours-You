using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletSound : MonoBehaviour
{
    [SerializeField] private AudioSource _tol;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            _tol.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            _tol.Stop();
        }
    }
}
