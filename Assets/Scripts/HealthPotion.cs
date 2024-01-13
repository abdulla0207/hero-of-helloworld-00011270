using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int HealthPoints = 30;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            if (player.CurrentHealth < 100)
            {
                player.HealthPotionCollected(HealthPoints);
                gameObject.SetActive(false);
            } 
        }
    }
}
