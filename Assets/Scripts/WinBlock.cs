using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBlock : MonoBehaviour
{
    public GameObject winMenuUI;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Cursor.lockState = CursorLockMode.Confined;
            ShowWinMenu();
            Time.timeScale = 0;
        }
    }
    
    private void ShowWinMenu()
    {
        winMenuUI.SetActive(true);
    }
}
