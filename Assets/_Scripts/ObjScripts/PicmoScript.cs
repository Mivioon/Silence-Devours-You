using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicmoScript : MonoBehaviour
{
    [SerializeField] Animator _anom2;
    [SerializeField] AudioSource _audio;

    public void animatorAel(){
        _anom2.SetTrigger("Loading");
        _audio.Play();
    }
}
