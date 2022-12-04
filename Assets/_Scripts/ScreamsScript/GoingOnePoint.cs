using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingOnePoint : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] GameObject _obj;

    [SerializeField] AudioSource _traps;
    [SerializeField] AudioSource _traps2;

    [SerializeField] Transform _trans;

    private void Update(){
        transform.position = Vector2.MoveTowards(transform.position, _trans.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if(_coll.gameObject.CompareTag("Player")){
            _obj.SetActive(true);
            _traps.Play();
            StartCoroutine("Load");
            _traps2.Stop();
            ControlPlayer._speed = 0f;
        }
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(6);
    }
}
