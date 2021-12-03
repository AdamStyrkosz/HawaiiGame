using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSuperArmor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LifeController.isSuperArmor = true;
            Destroy(gameObject);
        }
    }
}