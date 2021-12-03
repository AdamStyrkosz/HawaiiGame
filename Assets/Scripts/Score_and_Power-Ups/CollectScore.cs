using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScore : MonoBehaviour
{
    public Transform playerTransform;
    public bool isPulled = false;

    public int addedScore;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isPulled)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 50f * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            addedScore = 1 * ScoreController.scoreMultiplier;
            ScoreController.score += addedScore;
            //ScoreController.score += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player Bubble" && PowerUpController.isMagnet == true)
        {
            isPulled = true;
        }
    }

}
