using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : Health
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onEnemyDefeated;
    [SerializeField]
    private UnityEvent on70PercentHealth;
    [SerializeField]
    private UnityEvent on35PercentHealth;

    private EnemiesManager _enemiesManager;
    private BrickManager _brickManager;
    private bool _is70PercentHealth = false;
    private bool _is35PercentHealth = false;
    
    void Start()
    {
        _enemiesManager = FindObjectOfType<EnemiesManager>();
        _brickManager = GetComponentInParent<BrickManager>();

        MaxHealth = AmountHealth;

        transform.DOScale(1f, 0.5f).SetEase(Ease.InOutBack).SetId(transform);
    }

    void OnDestroy() 
    {
        DOTween.Kill(transform);
        _brickManager.DeleteObject();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            DecreaseHealth(1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            DecreaseHealth(MaxHealth);
        }
    }

    public override void DecreaseHealth(float value)
    {
        base.DecreaseHealth(value);

        CheckHealthPercent();

        if (AmountHealth <= 0)
        {
            onEnemyDefeated?.Invoke();

            _enemiesManager.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    private void CheckHealthPercent()
    {
        float percent = AmountHealth / MaxHealth * 100f;

        if (!_is70PercentHealth && percent <= 70f)
        {
            _is70PercentHealth = true;
            on70PercentHealth?.Invoke();
        }

        if (!_is35PercentHealth && percent <= 35f)
        {
            _is35PercentHealth = true;
            on35PercentHealth?.Invoke();
        }
    }
}
