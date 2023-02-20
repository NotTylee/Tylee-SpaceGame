using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame() 
    {
        SceneManager.LoadScene("Main");
    }

    public void GotoLevel()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void GotoLevelBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
