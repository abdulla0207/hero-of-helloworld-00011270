using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Health;
    public int CurrentHealth;

    public int Coins;
    public int CurrentCoins;
    public Text CoinText;

    public HealthBar healthBar;

    public UnityEvent<Player> onCoinCollected;
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = CurrentCoins.ToString();
        Health = 100;
        CurrentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }


    // Gives the damage to the player by taking the argument
    public void DamageToPlayer(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
        if(CurrentHealth <= 0)
        {
            print("Play Again");
        }
    }


    public void CoinsCollected(int pointsToAdd)
    {
        CurrentCoins += pointsToAdd;
        onCoinCollected.Invoke(this);

    }

   
    // Adds Health points when health potions collected
    public void HealthPotionCollected(int healthPointsToAdd)
    {
        if(CurrentHealth + healthPointsToAdd > 100)
        {
            CurrentHealth += 100;
            healthBar.SetHealth(CurrentHealth);
        }
        else
        {
            CurrentHealth += healthPointsToAdd;
            healthBar.SetHealth(CurrentHealth);
        }
    }


    public void Die()
    {
        if(CurrentHealth <= 0)
        {
            print("Player Died");
        }
    }

    
}
