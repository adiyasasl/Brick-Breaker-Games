using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthable
{
    public void IncreaseHealth(float value);
    public void DecreaseHealth(float value);
}
