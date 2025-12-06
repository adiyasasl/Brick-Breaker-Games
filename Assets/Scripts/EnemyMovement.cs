using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
