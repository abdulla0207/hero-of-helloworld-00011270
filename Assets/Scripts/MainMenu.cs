using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the first level when the Play Button
    // in Main Menu is pressed
    public void PlayLevel()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("LVL_1");
        Time.timeScale = 1f;
    }


    //Quits the game when the Quit button
    // is pressed
    public void Quit()
    {
        Application.Quit();
    }
}
