using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Renderer rend;
    private Color naturalColor;
    [SerializeField]
    private GameObject redTurret;
    [SerializeField]
    private GameObject cannon;
    private Boolean hasBuilt = false;
    private BuildManager buildManager;
    private Boolean errorColor = false;
    private float errorTime = 1f;
    private float waitedForError = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        naturalColor = rend.material.color;
        buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {

        if (errorColor)
        {
            waitedForError -= Time.deltaTime;
            if(waitedForError < 0)
            {
                errorColor = false;
                rend.material.color = naturalColor;
                waitedForError = errorTime;
            }
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !hasBuilt && buildManager.MakePurchase(1))
        {
            Instantiate(redTurret, transform.position, Quaternion.identity);
            hasBuilt = true;
        }
        else if (Input.GetMouseButtonDown(0) && !hasBuilt && !buildManager.MakePurchase(1))
        {
            rend.material.color = Color.red;
            errorColor = true;
        }
        
        if (Input.GetMouseButtonDown(1) && !hasBuilt && buildManager.MakePurchase(2))
        {
            Instantiate(cannon, transform.position, Quaternion.identity);
            hasBuilt = true;
        }
        else if (Input.GetMouseButtonDown(1) && !hasBuilt && !buildManager.MakePurchase(2))
        {
            rend.material.color = Color.red;
            errorColor = true;
        }

    }


    private void OnMouseEnter()
    {
        rend.material.color = Color.gray; 
    }

    private void OnMouseExit()
    {
        rend.material.color = naturalColor;
    }

}
