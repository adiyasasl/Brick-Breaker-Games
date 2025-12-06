using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Vector2 _limitMovement;
    private bool _isMovingLeft = true;
    private bool _isMovingRight = true;

    public float Speed = 30f;
    public bool CanMove = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPaddle();
    }

    public void ResetPaddle()
    {
        _rb.velocity = Vector2.zero;
        transform.position = new Vector2(0f, transform.position.y);
    }

    private void Update()
    {
        if (CanMove)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && _isMovingLeft)
            {
                _direction = Vector2.left;
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && _isMovingRight)
            {
                _direction = Vector2.right;
            }
            else
            {
                _direction = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            transform.Translate(_direction * Speed * Time.deltaTime);

            _limitMovement = transform.position;
            _limitMovement.x = Mathf.Clamp(_limitMovement.x, minX, maxX);

            transform.position = _limitMovement;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Wall")
        {
            _isMovingLeft = false;
        }
        else if (collision.gameObject.name == "Right Wall")
        {
            _isMovingRight = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Wall")
        {
            _isMovingLeft = true;
        }
        else if (collision.gameObject.name == "Right Wall")
        {
            _isMovingRight = true;
        }
    }
}
