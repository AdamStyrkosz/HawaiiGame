using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScoreMultiplier : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreController.scoreMultiplier = 2;
            PowerUpController.scoreMultiplierTimer = 30;
            PowerUpController.isScoreMultiplier = true;
            Destroy(gameObject);
        }
    }
}
