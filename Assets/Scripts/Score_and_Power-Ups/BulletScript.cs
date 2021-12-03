using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float expiryTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, expiryTime);
    }
}
