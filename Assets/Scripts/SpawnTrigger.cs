using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onGameFinish;

    [Header("Components")]
    [SerializeField]
    private SpawnManager[] spawnManager;
    [SerializeField]
    private SpawnArea spawnArea;

    private int _index = 0;

    public SpawnManager GetSpawnManager()
    {
        return spawnManager[_index];
    }

    public void NextSpawn()
    {
        _index++;
        if (_index < spawnManager.Length)
            spawnArea.CheckStage();
        else
        {
            onGameFinish?.Invoke();
            return;
        }
    }
}
