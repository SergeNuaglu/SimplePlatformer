using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            Destroy(this.gameObject);
        }
    }
}
