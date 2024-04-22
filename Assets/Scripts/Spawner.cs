using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform enemyCircle;
    [SerializeField] private Transform enemyTriangle;
    private int enemyCount;
    private int waveNumber = -2000;
    private Boolean lateGame = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            StartCoroutine(spawnEnemyWave(++waveNumber));

        }
    }
    IEnumerator spawnEnemyWave(int enemiesToSpawn)
    {
        Debug.Log("wave number is " + enemiesToSpawn);
        if (enemiesToSpawn > 4)
        {
            lateGame = true;
        }
        if(enemiesToSpawn > 0)
        {
            enemiesToSpawn *= enemiesToSpawn;
        }
        int boss = enemiesToSpawn / 3;

        for (int i = 0; i < enemiesToSpawn + boss; i++)
        {
            if(i < enemiesToSpawn && !lateGame)
            {
                Instantiate(enemyCircle, transform.position, transform.rotation);
                yield return new WaitForSeconds(0.6f);
            }
            else
            {
                Instantiate(enemyTriangle, transform.position, transform.rotation);
                yield return new WaitForSeconds(0.9f);
            }



        }

    }





}
