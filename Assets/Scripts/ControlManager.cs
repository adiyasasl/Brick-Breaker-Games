using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    [Header("Upgrade Card Button Components")]
    [SerializeField]
    private Button leftCardBtn;
    [SerializeField]
    private Button rightCardBtn;

    private bool _canControl = false;

    void Update()
    {
        if (!_canControl)
            return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            leftCardBtn.onClick.Invoke();
            return;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            rightCardBtn.onClick.Invoke();
            return;
        }
    }

    public void SetControllable(bool condition)
    {
        _canControl = condition;
    }
}
