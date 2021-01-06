using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void PlayerDeath();
    public event PlayerDeath OnPlayerDeath;
    
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _centerPoint;
    private float _direction;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _direction = -Input.GetAxisRaw("Horizontal");
        _transform.RotateAround(_centerPoint.transform.position, Vector3.forward, _speed * _direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
        }
    }
}
