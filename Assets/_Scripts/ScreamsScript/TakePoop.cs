using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakePoop : MonoBehaviour
{
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audio2;
    [SerializeField] Animator _anim;
    [SerializeField] Transform _point;
    public static int _Hp;
    [SerializeField] Text _textHp;
    [SerializeField] GameObject _HpImage;
    [SerializeField] SpriteRenderer _sprR;
    [SerializeField] Sprite _spr;
    [SerializeField] GameObject _obj;
 
    [SerializeField] bool _isIstinnaPopp;

    public static bool _isFind;
    public static bool _isStatic;

    private void Awake(){
        _isStatic = false;
        _Hp = 7;
        _isFind = false;
        _textHp.text = _Hp.ToString();
    }

    private void Update(){
        _textHp.text = _Hp.ToString();
        if (_Hp <= 0f){
            ControlPlayer._speed = 0f;
            SceneManager.LoadScene(6);
        }
        if (_isStatic == true){
            StartCoroutine("SpeedStop");
        }
    }

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player") && KnifePickUo._isPIck == true && _isFind == false){
            _anim.SetTrigger("Loading");
            ControlPlayer._speed = 0f;
            if (_isIstinnaPopp == false){
                _Hp -= 1;
                _audio.Play();
                gameObject.transform.position = _point.transform.position;
                _isStatic = true;
            }
            if (_isIstinnaPopp == true){
                _obj.SetActive(true);
                ControlPlayer._speed = 0f;
                _sprR.transform.localScale = new Vector3(0.1f, 0.1f, transform.localScale.z);
                gameObject.transform.position = _point.transform.position;
                _HpImage.SetActive(false);
                _sprR.sprite = _spr;
                _audio2.Play();
                _Hp = 3;
                _isFind = true;
                _isStatic = true;
            }
        }
    }

    IEnumerator SpeedStop(){
        yield return new WaitForSeconds(1.2f);
        ControlPlayer._speed = 3f;
        _isStatic = false;
    }
}
