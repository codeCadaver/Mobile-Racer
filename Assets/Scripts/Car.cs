using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _acceleration = 0.2f;
    [SerializeField] private float _turnSpeed = 200f;
    
    private bool _hasCrashed = false;
    private float _currentSpeed;
    private int _steerValue;
    

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
        // _currentSpeed = _hasCrashed ? _startSpeed : _currentSpeed += (_acceleration * Time.deltaTime);
        if (_hasCrashed)
        {
            _currentSpeed = _startSpeed;
            _hasCrashed = false;
        }
        else
        {
            _currentSpeed += (_acceleration * Time.deltaTime);
        }
        
        // Turn Car
        transform.Rotate(Vector3.up *(_steerValue * _turnSpeed * Time.deltaTime));
        // Steer();
        
        // Move Car forward
        transform.Translate(Vector3.forward * (Time.deltaTime * _currentSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit a Collider");
        }
    }

    public void Steer(int value)
    {
        _steerValue = value;
        // transform.Rotate(Vector3.up * ( _steerValue* _turnSpeed * Time.deltaTime));
    }
}
