using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelExpManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent _onTargetAchieved;

    [Header("Components")]
    [SerializeField]
    private Slider levelSlider;
    [SerializeField]
    private TextMeshProUGUI targetLevelTxt;

    [Header("Properties")]
    [SerializeField]
    private int targetLevelUp = 10;
    
    private int _currentLevelup = 0;

    void Start()
    {
        SetMaxLevel();
    }

    private void SetMaxLevel()
    {
        levelSlider.maxValue = targetLevelUp;
        levelSlider.value = 0;

        targetLevelTxt.text = $"{_currentLevelup}/{targetLevelUp}";
    }

    public void IncreaseLevel()
    {
        _currentLevelup++;

        levelSlider.value = _currentLevelup;

        targetLevelTxt.text = $"{_currentLevelup}/{targetLevelUp}";

        if (_currentLevelup == targetLevelUp)
        {
            _onTargetAchieved?.Invoke();

            targetLevelUp += 5;
            _currentLevelup = 0;
            SetMaxLevel();
        }
    }
}
