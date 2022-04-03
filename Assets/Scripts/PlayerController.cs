using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speed;

    private const string _jumpTrigger = "Jump";
    private const string _gunDownParameter = "GunDown";
    private const string _runParameter = "isRun";
    private const string _deathParameter = "Death";
    private Vector2 _velocity;
    private Vector3 _leftTurn = new Vector3(0, 180, 0);
    private Rigidbody2D _rigidbody;
    private bool _isGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _velocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (_velocity.x != 0 && _isGround)
        {
            _animator.SetBool(_runParameter, true);

            if (_velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(_leftTurn);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            _animator.SetBool(_runParameter, false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _animator.SetTrigger(_jumpTrigger);
            _rigidbody.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
            _isGround = false;
        }

        if (Input.GetButtonDown("GunDown") && _isGround)
        {
            _animator.SetBool(_gunDownParameter, true);
        }

        if (Input.GetButtonUp("GunDown") && _isGround)
        {
            _animator.SetBool(_gunDownParameter, false);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position = _rigidbody.position + _velocity * Time.deltaTime * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _isGround = true;
        }
    }

    public void Die()
    {
        _animator.SetBool(_deathParameter, true);
    }
}