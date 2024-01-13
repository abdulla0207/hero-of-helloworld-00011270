using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if(player != null)
        {
            player.CoinsCollected(23);
            gameObject.SetActive(false);
        }
    }
}
