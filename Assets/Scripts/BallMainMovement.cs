using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMainMovement : MonoBehaviour
{

    public float speed = 5;
    private bool _isMoving = false;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    
    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    
    void Update()
    {
        if (!_isMoving && _rigidbody)
        {
            if (Input.GetKeyDown("w"))
            {
                _direction = new Vector3(0f, 0.75f, 1f * speed);
                _isMoving = true;
            } else if (Input.GetKeyDown("s"))
            {
                _direction = new Vector3(0f, 0.75f, -1f * speed);
                _isMoving = true;
            } else if (Input.GetKeyDown("a"))
            {
                _direction = new Vector3(-1f * speed, 0.75f, 0f);
                _isMoving = true;
            } else if (Input.GetKeyDown("d"))
            {
                _direction = new Vector3(1f * speed, 0.75f, 0f);
                _isMoving = true;
            }
        } else if (_isMoving && _rigidbody)
        {
            _rigidbody.AddForce(_direction);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isMoving)
        {
            _isMoving = false;
            _direction = new Vector3(0f, 0.75f, 0f);
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
