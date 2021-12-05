using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverlay;
    public GameObject gameOverMenu;
    public GameObject submitScoreGroup;

    public Text nameInputText;
    public Button submitScoreButton;

    public Text score;

    void Update()
    {
        if(!LifeController.alive)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Time.timeScale = 0f;
        score.text = $"Score: {ScoreController.score}";

        gameOverlay.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(ScenesNames.mainMenu);
    }

    public void InputValueChanged()
    {
        if(nameInputText.text.Length > 0)
        {
            submitScoreButton.interactable = true;
        }
        else
        {
            submitScoreButton.interactable = false;
        }
    }

    public void SubmitButtonOnClick()
    {
        string name = nameInputText.text;

        Uri uri = new Uri("https://hikawaii.pythonanywhere.com/scoreboard/");
        string data = "{ \"nickname\": \"" + name + "\", \"points\": " + ScoreController.score + " }";

        WebClient client = new WebClient();
        client.Headers.Set("Content-Type", "application/json");

        string response = client.UploadString(uri, data);
        Debug.Log(response);

        submitScoreGroup.SetActive(false);
    }
}
