using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealthable
{
    [Header("Health Properties")]
    public float AmountHealth = 3f;
    public float MaxHealth;

    public virtual void DecreaseHealth(float value)
    {
        AmountHealth -= value;
    }

    public virtual void IncreaseHealth(float value)
    {
        AmountHealth += value;
    }
}
