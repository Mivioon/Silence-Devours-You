using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPick : MonoBehaviour
{
    [SerializeField] AudioSource _audio;

    [SerializeField] GameObject _ghost;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BockActive._isBocking == true){
            _audio.Play();
            _ghost.SetActive(true);
            FirstCreamer._isCreaming = true;
            ControlPlayer._speed = 0f;
            Destroy(gameObject);
        }
    }
}
