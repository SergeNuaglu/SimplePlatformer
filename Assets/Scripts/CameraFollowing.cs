using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _targetOfFollowing;
    [SerializeField] private float _movementSpeed;

    private Vector3 _targetPosition;
    private float _yPosition = 0;
    private float _minXPosition = 0;
    private float _maxXPosition = 10;
    private float _zDistance = 10;
    private float _startDuration = 5;

    private void Awake()
    {
        SetTargetPosition(_minXPosition);
        transform.DOMove(_targetPosition, _startDuration);
    }

    private void Update()
    {
        if (_targetOfFollowing != null)
        {
            if (_targetOfFollowing.position.x <= _minXPosition)
            {
                SetTargetPosition(_minXPosition);
            }
            else if (_targetOfFollowing.position.x >= _maxXPosition)
            {
                SetTargetPosition(_maxXPosition);
            }
            else
            {
                SetTargetPosition(_targetOfFollowing.position.x);
            }

            transform.position = Vector3.Lerp(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
        }
    }

    private void SetTargetPosition(float xPosition)
    {
        _targetPosition = new Vector3()
        {
            x = xPosition,
            y = _yPosition,
            z = _targetOfFollowing.position.z - _zDistance
        };
    }
}
