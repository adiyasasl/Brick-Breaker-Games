using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [Header("DEBUG ONLY")]
    [SerializeField]
    private bool isDebugMode = false;
    [SerializeField]
    private int debugIndex = 0;

    [Header("Card 1 Components")]
    [SerializeField]
    private TextMeshProUGUI powerNameOne;
    [SerializeField]
    private TextMeshProUGUI powerDescOne;

    [Header("Card 2 Components")]
    [SerializeField]
    private TextMeshProUGUI powerNameTwo;
    [SerializeField]
    private TextMeshProUGUI powerDescTwo;

    private List<Power> _power = new List<Power>();
    private List<GameObject> _ballObjs = new List<GameObject>();
    private int _randomPowerOne;
    private int _randomPowerTwo;

    void Start()
    {
        var power = FindObjectsOfType<Power>();

        _power = new List<Power>(power);
    }

    public void ShowBall(bool show)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        if (balls != null && !show)
        {
            _ballObjs.Clear();

            _ballObjs = new List<GameObject>(balls);
        }

        foreach (GameObject ball in _ballObjs)
            ball.SetActive(show);
    }

    public void ForceBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Ball behaviour = ball.GetComponent<Ball>();
            behaviour.ForceBall();
        }
    }

    public void SetupPowerCard()
    {
        _randomPowerOne = Random.Range(0, _power.Count);
        //_randomPowerTwo = Random.Range(0, _power.Count);

        if (!isDebugMode)
        {
            powerNameOne.text = _power[_randomPowerOne].PowerName;
            powerDescOne.text = _power[_randomPowerOne].PowerDesc;
        }
        else
        {
            powerNameOne.text = _power[debugIndex].PowerName;
            powerDescOne.text = _power[debugIndex].PowerDesc;
        }
    }

    public void StartCard1Power()
    {
        if (!isDebugMode)
            _power[_randomPowerOne].ActivePower();
        else
            _power[debugIndex].ActivePower();
    }

    public void StartCard2Power()
    {
        if (!isDebugMode)
            _power[_randomPowerTwo].ActivePower();
        else
            _power[debugIndex].ActivePower();
    }
}
