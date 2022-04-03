using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shotRange;

    private Transform _muzzle;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private bool _isShot;
    private float _scaleFactor = 3;
    private float _changeScaleTime = 1;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isShot = false;
    }

    private void FixedUpdate()
    {
        if (_isShot)
        {
            transform.DOScale(_scaleFactor, _changeScaleTime);
            _rigidbody.AddForce(_direction.normalized * _speed);

            if (transform.position.x - _muzzle.position.x >= _shotRange)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void AllowToShoot()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _direction = _muzzle.position - transform.position;
        _isShot = true;
    }

    public void SetAim(Transform muzzle)
    {
        _muzzle = muzzle;
    }


}
