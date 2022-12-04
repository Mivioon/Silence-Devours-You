using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] Animator _anim2;
    [SerializeField] GameObject _ecit;

    private void Start(){
        StartCoroutine("Startys");
    }

    IEnumerator Startys(){
        yield return new WaitForSeconds(1.2f);
        _anim.SetTrigger("Go");
        StartCoroutine("Endings");
    }

    IEnumerator Endings(){
        yield return new WaitForSeconds(18f);
        _anim.SetBool("Norm", true);
        StartCoroutine("Exit");
    }

    IEnumerator Exit(){
        yield return new WaitForSeconds(10f);
        _anim2.SetTrigger("Wake");
        StartCoroutine("Bu");
    }

    IEnumerator Bu(){
        yield return new WaitForSeconds(7f);
        _anim2.SetBool("Ponch", true);
    }
}
