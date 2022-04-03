using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent _killed;
    [SerializeField] private CoinsSpawner _coinsSpawner;

    private int _currentPoint;
    private int _startPointNumber = 0;
    private PlayerController _player;
    private Coroutine _killplayerJob;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _waypoints[_currentPoint].position)
        {
            _currentPoint++;

            if (_currentPoint >= _waypoints.Length)
            {
                _currentPoint = _startPointNumber;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Shooter>(out Shooter projectile))
        {
            _coinsSpawner.SetSpawnPoint(transform.position);
            _killed?.Invoke();
            Destroy(this.gameObject);
        }

        if (collision.TryGetComponent<PlayerController>(out _player))
        {
            _killplayerJob = StartCoroutine(KillPlayer());
        }
    }

    private IEnumerator KillPlayer()
    {
        float timeBeforeReload = 1.5f;

        while (_player != null)
        {
            _player.Die();
            Destroy(_player);
            yield return new WaitForSeconds(timeBeforeReload);
        }

        if (_player == null)
        {
            SceneManager.LoadScene(0);
            StopCoroutine(_killplayerJob);
        }
    }
}
