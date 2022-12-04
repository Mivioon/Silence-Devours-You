using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNext : MonoBehaviour
{
    [SerializeField] GameObject _objNext;

    private void Start(){
        StartCoroutine("Skiping");
    }

    IEnumerator Skiping(){
        yield return new WaitForSeconds(5);
        _objNext.SetActive(true);
        gameObject.SetActive(false);
    }
}
