using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BiggerBallTrigger : MonoBehaviour, ITimeable
{
    [Header("Properties")]
    [SerializeField]
    private float duration;
    [SerializeField]
    private float targetScale;

    private bool _isPowerActive = false;
    private float _currentDuration = 0;
    private Vector3 _defaultScale = Vector3.zero;

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
    }

    public void ActivePower()
    {
        _isPowerActive = true;
        _currentDuration = 0;

        transform.DOScale(targetScale, 1f).SetEase(Ease.OutBack);
    }

    public void TimeEnd()
    {
        _isPowerActive = false;
        transform.DOScale(_defaultScale, 1f).SetEase(Ease.OutBack);
    }
}
