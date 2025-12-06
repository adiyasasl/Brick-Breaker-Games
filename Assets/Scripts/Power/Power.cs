using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour, IPowerable
{
    public string PowerName;
    public string PowerDesc;
    
    public virtual void ActivePower() { }
}
