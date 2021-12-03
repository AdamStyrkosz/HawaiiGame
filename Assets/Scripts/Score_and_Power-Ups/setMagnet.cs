using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMagnet : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpController.magnetTimer = 10;
            PowerUpController.isMagnet = true;
            Destroy(gameObject);
        }
    }
}
