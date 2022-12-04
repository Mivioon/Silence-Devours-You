using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator _anim;

    [SerializeField] bool _isEnd = false;

    private void Start(){
        _anim.SetTrigger("Upi");
        Cursor.lockState = CursorLockMode.Locked;
        if (_isEnd == true){
            Cursor.lockState = CursorLockMode.Confined;
        }
        ControlPlayer._speed = 0f;
        StartCoroutine("SpeedStop");
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
