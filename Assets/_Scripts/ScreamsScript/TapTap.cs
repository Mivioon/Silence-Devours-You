using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTap : MonoBehaviour
{
    [SerializeField] AudioSource _tap;

    [SerializeField] GameObject _obj;
    [SerializeField] Transform _trans;
 
    private void OnTriggerEnter2D(Collider2D _coll){
        if(_coll.gameObject.CompareTag("Player") && FrizenWork._isFrizen == true && OffLightOne._isOff1 == false){
            gameObject.transform.position = _trans.gameObject.transform.position;

            _obj.SetActive(true);
            _tap.Play();
        }
    }
}
