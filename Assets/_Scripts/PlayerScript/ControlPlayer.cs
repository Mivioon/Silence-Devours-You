using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] private float _speedy;
    [SerializeField] public static float _speed;

    private bool _FacingRight;

    Rigidbody2D _rb; 
    Vector2 _movement; 

    private void Awake(){
        _rb = GetComponent<Rigidbody2D>();

        _speed = _speedy;
    }

    private void FixedUpdate(){
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (_movement.x < 0 && _FacingRight)
        {
            Flip();
        }
        else if (_movement.x >  0 && !_FacingRight)
        {
            Flip();
        }

        _rb.MovePosition(_rb.position +_movement * _speed * Time.fixedDeltaTime);
    }

    private void Flip(){
        _FacingRight = !_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
