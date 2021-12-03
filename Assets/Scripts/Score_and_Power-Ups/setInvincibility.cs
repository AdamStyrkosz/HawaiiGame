using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInvincibility : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LifeController.isInvincible = true;
            PowerUpController.invincibilityTimer = 30;
            PowerUpController.isInvincibility = true;
            Destroy(gameObject);
        }
    }
}
