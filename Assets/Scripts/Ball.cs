using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private TrailRenderer _trail;

    [Header("Properties")]
    [SerializeField]
    private Vector3 defaultScale = Vector3.zero;

    private Rigidbody2D _rb;
    private Vector2 _currentSpeed;
    private bool _canMove = true;

    public float Speed = 10f;
    public float MinVerticalAngle = 15f;
    public float MaxVerticalAngle = 75f;
    public bool FirstBall = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale;
    }

    private void Start()
    {
        if (FirstBall)
        {
            ResetBall();
            FirstBall = false;
        }
        else
            SetRandomTrajectory();
    }

    public void ResetBall()
    {
        _trail.enabled = false;
        _trail.Clear();
        _trail.enabled = true;

        _canMove = false;
        _rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        transform.localScale = Vector2.zero;

        transform.DOScale(defaultScale, 1f).SetEase(Ease.OutBack).OnComplete(() => SetRandomTrajectory());
    }

    public void ForceBall()
    {
        _rb.AddForce(_currentSpeed, ForceMode2D.Impulse);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2(Random.Range(-1f, 1f), -1f);
        _rb.AddForce(force.normalized * Speed, ForceMode2D.Impulse);
        _canMove = true;
    }

    private void FixedUpdate()
    {
        if (!_canMove)
            return;
    
        _rb.velocity = _rb.velocity.normalized * Speed;
        _currentSpeed = _rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            HandlePaddleBounce(collision);
            return;
        }

        if (collision.gameObject.CompareTag("Reset"))
            return;

        Vector2 v = _rb.velocity.normalized;

        // Prevent too flat horizontal bounces
        float angleFromHorizontal = Mathf.Abs(Vector2.Angle(v, Vector2.right));

        if (angleFromHorizontal < MinVerticalAngle)
        {
            float signY = Mathf.Sign(v.y);
            float signX = Mathf.Sign(v.x);

            // Recalculate direction so it’s at least minVerticalAngle from horizontal
            float correctedAngle = MinVerticalAngle * Mathf.Deg2Rad;
            v = new Vector2(Mathf.Cos(correctedAngle) * signX, Mathf.Sin(correctedAngle) * signY);
        }

        _rb.velocity = v.normalized * Speed;
    }

    private void HandlePaddleBounce(Collision2D collision)
    {
        Transform paddle = collision.transform;
        float paddleWidth = paddle.GetComponent<Collider2D>().bounds.size.x;

        // Relative hit position (-1 to 1)
        float hitPos = (transform.position.x - paddle.position.x) / (paddleWidth / 2f);
        hitPos = Mathf.Clamp(hitPos, -1f, 1f);

        float bounceAngle = hitPos * MaxVerticalAngle;
        Vector2 dir = Quaternion.Euler(0, 0, -bounceAngle) * Vector2.up;

        _rb.velocity = dir.normalized * Speed;
    }
}
