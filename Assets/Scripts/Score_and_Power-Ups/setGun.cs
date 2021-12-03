using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGun : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpController.ammo = 5;
            Destroy(gameObject);
        }
    }
}
