using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private Transform bullet;
    private float range = 3f;

    private float reloadTime = 1f;
    private float currentTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float angleOfTurret = 90f;
        if (target != null)
        {

            Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 20f);
            angleOfTurret = Vector3.Angle(transform.right, vectorToTarget); 

        }

        currentTime -= Time.deltaTime;

        if (currentTime < 0f && target != null && angleOfTurret < 10f) 
        {
            Shoot();
            currentTime = reloadTime;
        }


    }
    void UpdateTarget()
    {
        if(target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float distance;
            GameObject nearestEnemy = null;
            float shortestDistance = Mathf.Infinity;
            foreach(GameObject enemy in enemies)
            {

                distance = Vector3.Distance(transform.position, enemy.transform.position);

                if(distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range) 
            {
                target = nearestEnemy.transform;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, target.transform.position) > range)
            {
                target = null;
            }
        }
    }
    void Shoot()
    {
        
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);


        Instantiate(bullet, transform.GetChild(0).gameObject.transform.position, q );

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
