using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public static int lives;
    public int maxLives = 3;
    public GameObject livesText;
    public static bool alive, isSuperArmor, isInvincible;

    public Image[] pineapples;
    public Sprite pineapple;
    public Image shield;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        isSuperArmor = false;
        isInvincible = false;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < pineapples.Length; i++)
        {
            if (i < lives)
            {
                pineapples[i].enabled = true;
            } else
            {
                pineapples[i].enabled = false;
            }
        }

        if (isSuperArmor == true) shield.enabled = true;
        else shield.enabled = false;


        if (lives <= 0) {
            alive = false;
            livesText.GetComponent<Text>().text = "GameOver";
        }
        else
        {
            livesText.GetComponent<Text>().text = "Lives: " + lives;
        }
    }
}
