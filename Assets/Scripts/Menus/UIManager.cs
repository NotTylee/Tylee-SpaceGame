using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   public GameObject gameOverMenu;
   public GameObject timegameOverMenu;


    private void OnEnable()
    {
        Health.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        timegameOverMenu.SetActive(false);


    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
