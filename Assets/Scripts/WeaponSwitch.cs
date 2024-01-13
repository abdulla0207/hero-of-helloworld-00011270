using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject PistolUI;

    public void switchToPistol()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PistolUI.SetActive(true);
        }
    }
}
