using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    public Player player;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer"){
            player.DamageToPlayer(100);
        }
        
    }
}
