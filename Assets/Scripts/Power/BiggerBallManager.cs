using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerBallManager : Power
{
    public override void ActivePower()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach(var ball in balls)
        {
            ball.GetComponent<BiggerBallTrigger>().ActivePower();
        }
    }
}
