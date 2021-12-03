using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Transform player;
    public GameObject[] tilePrefabs;
    public GameObject superTile;
    public float zSpawn = 0;
    public float tileLenght = 20;
    private int tileCouter = 0;

    private int numberoftiles = 5;


    void Start()
    {
        for (int i = 0; i < numberoftiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z > zSpawn - (numberoftiles * tileLenght*2))  //*2 aby nie bylo widaæ renderu p³ytek    
        {
            if (tileCouter < 10)
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
                tileCouter++;
            }
            else
            {
                Instantiate(superTile, transform.forward * zSpawn, transform.rotation);
                tileCouter = 0;
                zSpawn += tileLenght;
            }

        }
    }

    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;
    }
}
