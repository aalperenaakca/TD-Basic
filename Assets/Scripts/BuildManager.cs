using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager
{
    
    private static int currentMoney = 190;
    private static int currentLives = 3;
    private static int currentScore = 0;
    public static Boolean canTouch = true;

    public void OnKillEnemy(int type)
    {
        if (type == 1 && canTouch)
        {
            currentMoney += 10;
            currentScore += 25;
        }
        else if (type == 2 && canTouch)
        {
            currentMoney += 15;
            currentScore += 40;
        }
    }


    public Boolean MakePurchase(int type)
    {
        if (type == 1 && currentMoney > 99 && canTouch) 
        {

            currentMoney -= 100;
            return true;

        }
    
        else if (type == 2 && currentMoney > 199 && canTouch)
        {

            currentMoney -= 200;
            return true;

        }
        return false;

    }

    public void OnFail()
    {
        if(currentLives > 0)
        {
            currentLives--;
        }
        if(currentLives == 0)
        {
            canTouch = false;
            GameController.GameOver();

        }
    }


    public int GetCurrentMoney()
    {
        return currentMoney;
    }
    
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetLives()
    {
        return currentLives;
    }

    public void ComeAgain()
    {
        currentLives = 3;
        currentScore = 0;
        currentMoney = 190;
        canTouch = true;
    }
}
