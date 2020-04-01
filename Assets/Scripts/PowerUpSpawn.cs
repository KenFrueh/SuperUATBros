using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    //Power up ref
    public GameObject powerUpPrefab;

    private GameObject spawnPowerup = null;

    void Start()
    {
        SpawnPowerUp();
    }

    public void SpawnPowerUp()
    {
        if (spawnPowerup == null)
        {
            spawnPowerup = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
        
    }

}
