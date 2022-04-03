using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Shooter _tamplate;
    [SerializeField] private Transform _muzzle;

    private Shooter _projectile;

    private void Start()
    {
        _projectile = Instantiate(_tamplate, transform);
        _projectile.SetAim(_muzzle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _projectile.AllowToShoot();
            _projectile = Instantiate(_tamplate, transform.position, Quaternion.identity,transform);
            _projectile.SetAim(_muzzle);
        }
    }
}
