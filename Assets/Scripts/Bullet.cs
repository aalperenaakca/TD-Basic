using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if(transform.position.y < -6 || transform.position.x < -13 || transform.position.y > 7 || transform.position.x > 13)
        {
            Destroy(gameObject);
        }

    }


}
