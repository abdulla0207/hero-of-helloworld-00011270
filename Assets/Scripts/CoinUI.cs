using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text CoinText;

    public void ChangeCoinText(Player player)
    {
        CoinText.text = player.CurrentCoins.ToString();
    }
}
