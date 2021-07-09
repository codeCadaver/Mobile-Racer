using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _acceleration = 0.2f;
    
    private float _currentSpeed;
    private bool _hasCrashed = false;
    

    private void Start()
    {
        _currentSpeed = _startSpeed;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Check if car has crashed
        _currentSpeed = _hasCrashed ? _startSpeed : _currentSpeed += (_acceleration * Time.deltaTime);
        
        // Move Car forward
        transform.Translate(Vector3.forward * (Time.deltaTime * _currentSpeed));
    }
}
