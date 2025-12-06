using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughBallTrigger : MonoBehaviour, ITimeable
{
    [Header("Properties")]
    [SerializeField]
    private float duration;
    [SerializeField]
    private LayerMask mask;

    [Header("Raycast Properties")]
    [SerializeField]
    private Vector2 raySize;
    [SerializeField]
    private float angleSize;

    private Collider2D _collider;
    private bool _isPowerActive = false;
    private float _currentDuration = 0;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (_isPowerActive)
        {
            _currentDuration += Time.deltaTime;
            _collider.isTrigger = true;

            if (_currentDuration > duration)
                TimeEnd();
        }
        else
        {
            return;
        }

        var ray = Physics2D.OverlapBox(transform.position, raySize, angleSize, mask);

        if (ray != null)
        {
            if (ray.CompareTag("Wall") || ray.CompareTag("Paddle"))
            {
                Debug.Log("Hit Wall");
                _collider.isTrigger = false;
            }
        }
    }

    public void ActivePower()
    {
        _isPowerActive = true;
        _currentDuration = 0;
    }

    public void TimeEnd()
    {
        _isPowerActive = false;
        _collider.isTrigger = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, raySize);
    }
}
