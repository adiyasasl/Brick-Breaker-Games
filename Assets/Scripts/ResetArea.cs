using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArea : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            var ball = collision.collider.GetComponent<Ball>();
            Destroy(ball.gameObject);
        }
    }
}
