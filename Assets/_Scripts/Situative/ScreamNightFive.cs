using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamNightFive : MonoBehaviour
{
    [SerializeField] GameObject _scream;

    private void Update(){
        if (BockActive._isBocking == true){
            _scream.SetActive(true);
        }
    }
}
