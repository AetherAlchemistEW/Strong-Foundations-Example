using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This object will keep track of all the enemies which have been instantiated and then killed so we can reuse them
public class ObjectPool : MonoBehaviour
{
    //List
    public List<BaseEnemy> enemyPool; //There's also a type call a 'queue' we could use
    public BaseEnemy enemyPrefab;
    public Vector3 spawnPosition;

    //We need an enemy, spawn one.
    public void SpawnEnemy()
    {
        //If we have one in reserve that we already instantiated, do that.
        if(enemyPool.Count > 0)
        {
            enemyPool[0].Reset(spawnPosition);              //We don't want it spawning where it died
            enemyPool[0].gameObject.SetActive(true);        //Enable it again
            enemyPool[0].transform.parent = null;           //We don't want it to stay our child
        }
        else //We don't have any in reserve, so make a new one.
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    //Rather than just destroy the enemy, we'll 'despawn it' and add it to the pool
    public void DespawnEnemy(BaseEnemy enemyToDespawn)
    {
        enemyPool.Add(enemyToDespawn);                      //Add it to the pool
        enemyToDespawn.gameObject.SetActive(false);         //Deactivate it so it 'dies'
        enemyToDespawn.transform.parent = this.transform;   //Just for ease of access and clarity, not required
    }
}
