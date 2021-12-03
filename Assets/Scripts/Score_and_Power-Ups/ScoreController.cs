using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;
    public static int scoreMultiplier = 1;
    // Update is called once per frame

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
