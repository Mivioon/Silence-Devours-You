using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRamble : MonoBehaviour
{
    [SerializeField] Transform _one;
    [SerializeField] Transform _two;

    void Update(){
        _one.transform.position = _two.transform.position;
    }
}
