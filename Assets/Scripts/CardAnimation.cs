using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject panel;

    [Header("Ease Properties")]
    [SerializeField]
    private Ease ease;

    private Vector3 _defaultPos;
    private Vector3 _defaultRotate;

    public bool PanelSetActive = false;

    void Start()
    {
        _defaultPos = transform.position;
        _defaultRotate = transform.eulerAngles;

        if(PanelSetActive)
            panel.SetActive(false);
    }

    public void AppearCard()
    {
        transform.DOMoveY(0f, 0.5f).SetEase(Ease.OutBack);
        transform.DORotate(Vector3.zero, 0.5f).OnComplete(() => transform.DOScale(Vector3.one, 0.5f).SetEase(ease));
    }

    void OnDisable()
    {
        ResetValue();
    }

    private void ResetValue()
    {
        transform.position = _defaultPos;
        transform.eulerAngles = _defaultRotate;
        transform.localScale = Vector3.one * 0.5f;
    }
}
