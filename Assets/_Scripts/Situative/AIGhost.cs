using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGhost : MonoBehaviour
{
    public static float _speed;
    [SerializeField] float _startWaitTime;
    [SerializeField] float _minDistance;

    [SerializeField] Transform[] _points;
    [SerializeField] Transform _playerPoint;
    [SerializeField] Transform _pointQUA;
    
    [SerializeField] bool _isAgry;

    private float _waitTime;
    private int _randomPoint;

    private void Start(){
        _randomPoint = Random.Range(0, _points.Length);
        _waitTime = _startWaitTime;
        _speed = 50f;
        _minDistance = 0f;
        StartCoroutine("OK");
    }

    private void Update(){
        if (_isAgry == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _points[_randomPoint].position, _speed * Time.deltaTime);
            _FlipWithPoints();
            if (Vector2.Distance(transform.position, _points[_randomPoint].position) < 0.2f)
            {
               
               if (_waitTime <= 0)
               {
                 _randomPoint = Random.Range(0, _points.Length);
                 _waitTime = _startWaitTime;
               }
               else
               {
                 _waitTime -= Time.deltaTime;
               }
            }
        }

        if (Vector2.Distance(transform.position, _playerPoint.transform.position) < _minDistance)
        {
            _isAgry = true;
            if (_isAgry == true)
            {
               transform.position = Vector2.MoveTowards(transform.position, _playerPoint.transform.position, _speed * Time.deltaTime);
               _FlipWithPlayer();
            }
        }
        else if (Vector2.Distance(transform.position, _playerPoint.transform.position) > _minDistance)
        {
          _isAgry = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            gameObject.transform.position = _pointQUA.transform.position;
            _speed = 0f;
            _minDistance = 0f;
            StartCoroutine("OK2");
            StartCoroutine("SpeedNormal");
        }
    }

    private void _FlipWithPlayer(){
        if (_playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void _FlipWithPoints(){
        if (_points[_randomPoint].transform.position.x < transform.position.x)
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_points[_randomPoint].transform.position.x > transform.position.x)
        {
          transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    IEnumerator OK(){
        yield return new WaitForSeconds(7);
        _minDistance = 4f;
    }

    IEnumerator OK2(){
        yield return new WaitForSeconds(35);
        _minDistance = 4f;
    }

    IEnumerator SpeedNormal(){
        yield return new WaitForSeconds(30);
        _speed = 50f;
    }
}
