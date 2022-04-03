using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Destroy(this.gameObject);
        }
    }
}
