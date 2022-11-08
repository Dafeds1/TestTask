using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _verticalSpeed = 10f;
    private Rigidbody _rigidbody;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isRunning = true;
        EventBus.OnGameOver += GameOver;
    }

    private void OnDestroy()
    {
        EventBus.OnGameOver -= GameOver;
    }

    private void Start()
    {
        StartCoroutine(SpeedIncrease(_isRunning));
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Touch touch = Input.GetTouch(0);
            if (_rigidbody.position.y < 7)
            {
                _rigidbody.MovePosition(new Vector3(0,_rigidbody.position.y + (_verticalSpeed * Time.deltaTime),0)); 
            }
        } 
    }
    private IEnumerator SpeedIncrease(bool isRunning)
    {
        while (_isRunning == true)
        {
            _verticalSpeed++;
            Debug.Log(_verticalSpeed);
            yield return new WaitForSeconds(15);
        }
    }

    public void GameOver(bool value)
    {
        _isRunning = value;
        StopCoroutine(SpeedIncrease(_isRunning));
        _verticalSpeed = 10;
    }
}
