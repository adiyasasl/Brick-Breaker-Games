using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendPaddle : Power, ITimeable
{
    [Header("Properties")]
    [SerializeField]
    private float duration;
    [SerializeField]
    private float extendSize = 2f;

    private bool _isPowerActive = false;
    private Vector3 _defaultScale;
    private float _currentDuration = 0f;

    void Start()
    {
        _defaultScale = transform.localScale;
    }

    void Update()
    {
        if (_isPowerActive)
        {
            _currentDuration += Time.deltaTime;
            
            if (_currentDuration > duration)
                TimeEnd();
        }
        else
            return;
    }

    public override void ActivePower()
    {
        _isPowerActive = true;
        _currentDuration = 0f;
        transform.localScale = new Vector3(_defaultScale.x + extendSize, _defaultScale.y, _defaultScale.z);
    }

    public void TimeEnd()
    {
        transform.localScale = _defaultScale;
        _isPowerActive = false;
    }
}
