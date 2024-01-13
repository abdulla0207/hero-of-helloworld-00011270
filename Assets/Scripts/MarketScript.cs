using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketScript : MonoBehaviour
{

    public GameObject PressEUI;
    public GameObject MarketTabUI;
    public Player player;
    public GameObject Rifle;
    public GameObject SMMG;
    public GameObject Pistol;

    private int eCounter = 0;

    private void Update()
    {
        if (PressEUI.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.Confined;
                eCounter++;
                ShowMarketInventory(true, 0);
            }
            if(eCounter == 2)
            {
                Cursor.lockState = CursorLockMode.Locked;
                ShowMarketInventory(false, 1);
                eCounter = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PressEUI.SetActive(true);
    }

    private void ShowMarketInventory(bool isActive, float gamePauseValue)
    {
        MarketTabUI.SetActive(isActive);
        Time.timeScale = gamePauseValue;
    }
    private void OnTriggerExit(Collider other)
    {
        PressEUI.SetActive(false);
    }

    public void BuyRifle()
    {
        if(player.CurrentCoins <= 0 || player.CurrentCoins < 30)
        {
            return;
        }
        else
        {

            Rifle.SetActive(true);
            SMMG.SetActive(false);
            Pistol.SetActive(false);
            player.CoinsCollected(-30);
        }
        
    }

    public void BuySMMG()
    {
        if (player.CurrentCoins <= 0 || player.CurrentCoins < 20)
        {
            return;
        }
        else
        {
            Rifle.SetActive(false);
            SMMG.SetActive(true);
            Pistol.SetActive(false);
            player.CoinsCollected(-20);
        }

    }
}
