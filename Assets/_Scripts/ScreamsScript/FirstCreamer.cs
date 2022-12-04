using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCreamer : MonoBehaviour
{
    [SerializeField] GameObject _ghost;
    [SerializeField] GameObject _light;
    [SerializeField] AudioSource _lightOff; 

    public static bool _isCreaming;

    private void Awake(){
        _isCreaming = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && BenzolPickUp._isLiting == true){
            _light.SetActive(false);
            _ghost.SetActive(true);
            _lightOff.Play();
            Destroy(gameObject);
        }
    }
}
