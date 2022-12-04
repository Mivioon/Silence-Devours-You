using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsOkayFile : MonoBehaviour
{
    [SerializeField] GameObject _audio;

    private void Update(){
         if (ActionPlay._isOuty == true){
            _audio.SetActive(true);
        }
        if (ActionPlay._isOuty == false){
            _audio.SetActive(false);
        } 
    }
}
