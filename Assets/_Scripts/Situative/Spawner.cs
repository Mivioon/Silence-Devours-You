using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _timer;
    [SerializeField] GameObject _spawnObj;

    [Header("SpawnPosX")]
    [SerializeField] float _xOne;
    [SerializeField] float _xTwo;

    [Header("SpawnPosY")]
    [SerializeField] float _yOne;
    [SerializeField] float _yTwo;

    void Start(){
        StartCoroutine("Spawn");
    }

    void Restart(){
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn(){
        yield return new WaitForSeconds(_timer);
        gameObject.transform.position = new Vector2(Random.Range(_xOne, _xTwo), Random.Range(_yOne, _yTwo));
        Instantiate(_spawnObj, gameObject.transform.position, Quaternion.identity);
        Restart();
    }
}
