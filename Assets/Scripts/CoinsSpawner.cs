using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _tamplate;
    [SerializeField] private Vector3 _spawnPoint;

    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void Spawn()
    {
        Instantiate(_tamplate, _spawnPoint, Quaternion.identity);
    }
}
