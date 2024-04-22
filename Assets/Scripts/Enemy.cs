using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform nextFlag;

    [SerializeField]
    private int enemyType;
    [SerializeField]
    private float speed = 100f;
    private int flagIndex = 0;
    [SerializeField]
    private int enemyHealth = 5;
    private BuildManager buildManager;
    [SerializeField]
    private Image healthBar;



    // Start is called before the first frame update
    void Start()
    {
        
        nextFlag = Flags.flags[flagIndex];
        buildManager = new BuildManager();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 normalizedDirection = (nextFlag.position - transform.position).normalized;


        if (Vector2.Distance(transform.position, nextFlag.position) <= 0.01f)
        {
            flagIndex++;
            if (flagIndex == Flags.flags.Length)
            {
                return;
            }
            nextFlag = Flags.flags[flagIndex];
        }

        transform.Translate(normalizedDirection * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Bullet")
        {


            Destroy(other.gameObject);
            enemyHealth--;
            if(enemyHealth == 5)
            {
                speed *= 2;
            }
            if(enemyHealth == 0)
            {
                buildManager.OnKillEnemy(enemyType);
                Destroy(gameObject);
            }
            if(enemyType == 1) 
            { 
                healthBar.fillAmount = enemyHealth / 5f;
            }
            else if (enemyType == 2)
            {
                healthBar.fillAmount = enemyHealth / 10f;
            }
        }
        else if (other.gameObject.transform.tag == "CannonBullet")
        {
            enemyHealth--;
            if (enemyHealth == 5)
            {
                speed *= 2;
            }
            if (enemyHealth == 0)
            {
                buildManager.OnKillEnemy(enemyType);
                Destroy(gameObject);
            }
            if (enemyType == 1)
            {
                healthBar.fillAmount = enemyHealth / 5f;
            }
            else if (enemyType == 2)
            {
                healthBar.fillAmount = enemyHealth / 10f;
            }
        }
        else if(other.gameObject.transform.tag == "GameEnd")
        {
            buildManager.OnFail();
            Destroy(gameObject);
        }



    }
    

}
