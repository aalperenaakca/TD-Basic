using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject over;

    private static Boolean check = false;
    private static BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            over.SetActive(true);
        }
        else
        {
            over.SetActive(false);
        }


    }
    public static void GameOver()
    {
        check = true;
    }
    public void StartGame()
    {
        check = false;
        buildManager.ComeAgain();
        SceneManager.LoadScene(0);
    }


}
