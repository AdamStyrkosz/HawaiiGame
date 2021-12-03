using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (LifeController.alive == true && LifeController.isInvincible == false && LifeController.isSuperArmor == false)
            {
                LifeController.lives -= 1;
            }
            if (LifeController.isSuperArmor == true)
            {
                LifeController.isSuperArmor = false;
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
