using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image _imageBar;
    [SerializeField] AudioSource _audio;
    [SerializeField] float _maxHp = 100f;
    public static float _hp;
    public static float _minusHp;

    [SerializeField] PostProcessVolume _main;
    [SerializeField] PostProcessProfile _hund;
    [SerializeField] PostProcessProfile _hund_six;
    [SerializeField] PostProcessProfile _hund_third;

    private void Start(){
        _maxHp = 100f;
        _minusHp = 2f;
        HeartPlus._source = _audio;
        _hp = _maxHp;
    }

    private void Update(){
        _imageBar.fillAmount = _hp / _maxHp;
        _hp -= _minusHp * Time.deltaTime;
        if (_hp <= 0f){
            SceneManager.LoadScene(5);
        }
        if (_hp >= 101f){
            _hp = 100f;
        }
        if (_hp >= 61f){
            _main.profile = _hund;
        }
        if (_hp <= 60f && _hp >= 31f){
            _main.profile = _hund_six; 
        }
        if (_hp <= 30f){
            _main.profile = _hund_third;
        }
    }
}
