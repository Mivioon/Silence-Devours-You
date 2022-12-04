using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlay : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] Transform _pointOne;
    [SerializeField] Transform _pointTwo;

    [SerializeField] Transform _pointOneS;
    [SerializeField] Transform _pointTwoS;

    [SerializeField] Transform _pointOneN;
    [SerializeField] Transform _pointTwoN;

    [Header("OBJ")]
    [SerializeField] GameObject _tyman;
    [SerializeField] GameObject _tymanS;
    [SerializeField] GameObject _tymanN;
    //House
    [SerializeField] GameObject _objClock;
    [SerializeField] GameObject _objTymba;
    [SerializeField] GameObject _objBooks;
    [SerializeField] GameObject _objArt;
    [SerializeField] GameObject _objRain;
    //Clad
    [SerializeField] GameObject _objShkav;
    [SerializeField] GameObject _objGenerator;
    [SerializeField] GameObject _objVedro; 
    //Radio
    [SerializeField] GameObject _objBigTymba;
    [SerializeField] GameObject _Tymba;
    [SerializeField] GameObject _rr;

    [SerializeField] GameObject _risenOne;
    [SerializeField] GameObject _risenTwo;
    [SerializeField] GameObject _risenThree;
    [SerializeField] GameObject _tree;

    [Header("Audio")]
    [SerializeField] AudioSource _gameTheme;
    [SerializeField] AudioSource _openSound;

    [SerializeField] AudioClip _knock;
    [SerializeField] AudioClip _beach;
    [SerializeField] AudioClip _motor;
    [SerializeField] AudioClip _music;

    [Header("Animation")]
    [SerializeField] Animator _animLoad;

    [SerializeField] private bool _isOut;
    public static bool _isOuty;
    [SerializeField] private bool _isNight;

    private void Awake(){
        _isOuty = _isOut;
        if (_isNight == true){
            _gameTheme.clip = _knock;
            _gameTheme.Play();
        }
    }

    private void Update(){
        _isOuty = _isOut;
        if (_isOut == false){
            _tyman.SetActive(true);
            _tymanS.SetActive(true);
            _tymanN.SetActive(true);
            _objClock.SetActive(true);
            _objTymba.SetActive(true);
            _objBooks.SetActive(true);
            _objArt.SetActive(true);
            _objGenerator.SetActive(true);
            _objShkav.SetActive(true);
            _tree.SetActive(false);
            _objVedro.SetActive(true);
            _Tymba.SetActive(true);
            _objBigTymba.SetActive(true);
            _rr.SetActive(true);
            //False
            _risenOne.SetActive(false);
            _risenTwo.SetActive(false);
            _risenThree.SetActive(false);
            _objRain.SetActive(false);
        } else if (_isOut == true){
            _tyman.SetActive(false);
            _tymanS.SetActive(false);
            _tymanN.SetActive(false);
            _objClock.SetActive(false);
            _tree.SetActive(true);
            _objTymba.SetActive(false);
            _objBooks.SetActive(false);
            _objArt.SetActive(false);
            _objGenerator.SetActive(false);
            _objShkav.SetActive(false);
            _objVedro.SetActive(false);
            _Tymba.SetActive(false);
            _objBigTymba.SetActive(false);
            _rr.SetActive(false);
            //True
            _risenOne.SetActive(true);
            _risenTwo.SetActive(true);
            _risenThree.SetActive(true);
            _objRain.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Action")){
            if (_isOut == false){
                transform.position = _pointOne.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = true;
                _gameTheme.clip = _beach;
                _gameTheme.Play();
                _openSound.Play();
                _animLoad.SetTrigger("Loading");
            }
            else if (_isOut == true){
                transform.position = _pointTwo.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = false;
                _gameTheme.clip = _knock;
                _gameTheme.Play();
                _openSound.Play();
                _animLoad.SetTrigger("Loading");
            }
        }

        if (_coll.gameObject.CompareTag("ActiOn")){
            if (_isOut == false){
                transform.position = _pointOneS.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = true;
                _gameTheme.clip = _beach;
                _gameTheme.volume = 0.5f;
                _gameTheme.Play();
                _openSound.Play();
                _animLoad.SetTrigger("Loading");
            }
            else if (_isOut == true){
                transform.position = _pointTwoS.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = false;
                _gameTheme.clip = _motor;
                _gameTheme.volume = 0.25f;
                _gameTheme.Play();
                _openSound.Play();
                if (OffLightOne._isOff1 == true){
                    _gameTheme.Stop();
                }
                _animLoad.SetTrigger("Loading");
            }
        }

                if (_coll.gameObject.CompareTag("ActiON")){
            if (_isOut == false){
                transform.position = _pointOneN.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = true;
                if (LevelManager._loadyScene == 6 && _isOut == true || LevelManager._loadyScene == 8 && _isOut == true){
                    _gameTheme.pitch = 1f;
                }
                _gameTheme.clip = _beach;
                _gameTheme.Play();
                _openSound.Play();
                _animLoad.SetTrigger("Loading");
                
            }
            else if (_isOut == true){
                transform.position = _pointTwoN.transform.position;
                ControlPlayer._speed = 0f;
                StartCoroutine("SpeedStop");
                _isOut = false;
                if (LevelManager._loadyScene == 6 && _isOut == false || LevelManager._loadyScene == 8 && _isOut == false){
                    _gameTheme.pitch = -0.77f;
                }
                _gameTheme.clip = _music;
                _gameTheme.Play();
                _openSound.Play();
                _animLoad.SetTrigger("Loading");
            }
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
    }
}
