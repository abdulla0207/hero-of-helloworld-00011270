using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseMenu : MonoBehaviour
{

    public GameObject looseMenuUI;
    public Player player;
    // Update is called once per frame
    void Update()
    {
        if(player.CurrentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            looseMenuUI.SetActive(true);
        }
    }

    public void RestartGame1()
    {
        
        SceneManager.LoadScene("LVL_1");
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("LVL2");
    }
    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Menu");
    }
}
