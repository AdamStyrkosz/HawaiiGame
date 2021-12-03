using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public GameObject timerText;
    public static float scoreMultiplierTimer, invincibilityTimer, magnetTimer, superJumpTimer;
    public static bool isScoreMultiplier, isInvincibility, isMagnet, isSuperJump;
    public static int ammo;

    // Start is called before the first frame update
    void Start()
    {
        scoreMultiplierTimer = invincibilityTimer = magnetTimer = superJumpTimer = ammo = 0;
        isScoreMultiplier = isInvincibility = isMagnet = isSuperJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.GetComponent<Text>().text = magnetTimer.ToString("0");
        if (magnetTimer <= 10)
        {
            timerText.GetComponent<Text>().text = "0" + magnetTimer.ToString("0");
        }

        if (isScoreMultiplier)
        {
            scoreMultiplierTimer -= Time.deltaTime;
            if (scoreMultiplierTimer < 0)
            {
                isScoreMultiplier = false;
                ScoreController.scoreMultiplier = 1;
            }
        }

        if (isInvincibility)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer < 0)
            {
                isInvincibility = false;
                LifeController.isInvincible = false;
            }
        }
        if (isMagnet)
        {
            magnetTimer -= Time.deltaTime;
            if (magnetTimer < 0)
            {
                isMagnet = false;
            }
        }

    }
}
