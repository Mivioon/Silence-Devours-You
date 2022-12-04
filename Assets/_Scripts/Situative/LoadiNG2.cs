using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadiNG2 : MonoBehaviour
{
    private void Start(){
        StartCoroutine("Load");
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(45);
        SceneManager.LoadScene(6);
    }
}
