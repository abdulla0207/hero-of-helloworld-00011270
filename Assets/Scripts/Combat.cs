using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    Player playerStats;

    private void Start()
    {
        playerStats = GetComponent<Player>();
    }
    public void PlayerAttack(Player stats)
    {
    }
}
