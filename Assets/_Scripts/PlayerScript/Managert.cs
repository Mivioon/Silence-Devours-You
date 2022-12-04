using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managert : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] AudioSource _audio;

    private void Start(){
        _anim.SetTrigger("Svetila");
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine("Play");
    }

    IEnumerator Play(){
        yield return new WaitForSeconds(2);
        _audio.Play();
    }
}
