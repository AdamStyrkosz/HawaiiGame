using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {

        Time.timeScale = 1f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ScoreController.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(ScenesNames.level);       
    }
}
