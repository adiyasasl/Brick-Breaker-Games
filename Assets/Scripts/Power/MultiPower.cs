using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPower : Power
{
    public override void ActivePower()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach(var ball in balls)
        {
            Instantiate(ball, ball.transform.position, Quaternion.identity);
        }
    }
}
