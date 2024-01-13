using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int CurrentHealth;
    void Awake()
    {
        Health = 100;
        CurrentHealth = Health;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(10);
        }
        Die();
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    void Die()
    {
        if (CurrentHealth <= 0)
        {
            print("Enemy Died");
        }
    }
}
