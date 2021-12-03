using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ScoreController.score = 0;
        SceneManager.LoadScene(ScenesNames.level);       
    }
}
