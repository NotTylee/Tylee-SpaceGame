using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void OpenScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenScene2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
