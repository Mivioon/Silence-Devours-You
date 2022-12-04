using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Transform _endPoint;

    [SerializeField] float _speed;

    private void Start(){
        StartCoroutine("Delete");
        StartCoroutine("SpeedStop");
    }

    private void Update(){
        if (FirstCreamer._isCreaming == true){
            transform.position = Vector2.MoveTowards(transform.position, _endPoint.transform.position, _speed * Time.deltaTime);
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(3.5f);
        ControlPlayer._speed = 3f;
    }

    IEnumerator Delete(){
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
