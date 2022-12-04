using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPlus : MonoBehaviour
{
    public static AudioSource _source;
    [SerializeField] Transform _point;

    private void OnTriggerEnter2D(Collider2D _coll){
        if (_coll.gameObject.CompareTag("Player")){
            HPBar._hp += 17f;
            _source.Play();
            gameObject.transform.position = _point.transform.position;
            StartCoroutine("Delete");
        }
    }

    IEnumerator Delete(){
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
