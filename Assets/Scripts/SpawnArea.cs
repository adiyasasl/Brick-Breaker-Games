using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnArea : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent _onEnemySpawned;

    [Header("Spawn Components")]
    [SerializeField]
    private Transform enemiesParent;
    [SerializeField]
    private SpawnTrigger spawnTrigger;
    [SerializeField]
    private BrickGrid brickGrid;
    [SerializeField]
    private Slider waveSlider;

    private int _currentWave = 0;
    private int _currentStage = 0;
    private bool _nextLevel = false;

    public bool GameFinish = false;
    public bool CanSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnBrick(2f));
    }

    public IEnumerator SpawnBrick(float delay)
    {
        yield return new WaitForSeconds(delay);

        var enemiesManager = FindObjectOfType<EnemiesManager>();
        var manager = spawnTrigger.GetSpawnManager();
        var wave = manager.GetWaveSpawn(_currentWave);

        GameObject enemy = Instantiate(wave.GetCurrentSpawn(_currentStage).EnemiesObj, transform.position, Quaternion.identity);

        enemiesManager.AddEnemy();

        enemy.transform.SetParent(enemiesParent);

        brickGrid.SetGridPosition();

        Debug.Log($"Enemy has been spawned, Current Wave = {_currentWave} and Current Stage = {_currentStage} with name = {wave.GetCurrentSpawn(_currentStage).name}");

        CheckStage();
    }

    public void CheckStage()
    {
        var manager = spawnTrigger.GetSpawnManager();
        var wave = manager.GetWaveSpawn(_currentWave);
        var stage = wave.GetCurrentSpawn(_currentStage);

        if (_currentStage < wave.InitSpawns.Length - 1)
        {
            StartCoroutine(SpawnBrick(stage.DelayBeforeSpawn));
            
            if(!_nextLevel)
                _currentStage++;
            else
                _nextLevel = false;

            Debug.Log("Next Stage");
        }
        else
        {
            CheckWave();
        }
    }

    private void CheckWave()
    {
        var manager = spawnTrigger.GetSpawnManager();

        if (_currentWave < manager.WaveSpawns.Length - 1)
        {
            _currentWave++;

            var wave = manager.GetWaveSpawn(_currentWave);
            var stage = wave.GetCurrentSpawn(_currentStage);
            
            _currentStage = 0;

            StartCoroutine(SpawnBrick(stage.DelayBeforeSpawn));

            Debug.Log("Next Wave");
        }
        else
        {
            Debug.Log("No more Wave");
            _currentWave = 0;
            _currentStage = 0;

            _nextLevel = true;
        }
    }



    #region Ghost Breaker Persis
    // Versi Ghost Breaker persis

    // [Header("Spawn Properties")]
    // [SerializeField]
    // private float minSpawnX = -1.72f;
    // [SerializeField]
    // private float maxSpawnX = 1.72f;

    // private float _currentDelaySpawn = 0f;
    // private int _currentSpawn = 0;
    // private int _currentIndex = 0;
    // private float _delayStartSpawn = 0f;
    // private float _currentDelayStartSpawn = 0f;

    // void Start()
    // {
    //     waveSlider.maxValue = spawnTrigger.GetSpawnManager().GetTotalEnemy();
    // }

    // void Update()
    // {
    //     if (GameFinish)
    //         return;

    //     _currentDelaySpawn += Time.deltaTime;

    //     if (_currentIndex < spawnTrigger.GetSpawnManager().initializeSpawns.Length && CanSpawn)
    //     {
    //         if (_currentDelaySpawn > spawnTrigger.GetSpawnManager().GetInitSpawn(_currentIndex).DelaySpawn && _currentSpawn < spawnTrigger.GetSpawnManager().GetInitSpawn(_currentIndex).AmountSpawn)
    //         {
    //             float random = Random.Range(minSpawnX, maxSpawnX);
    //             GameObject enemy = Instantiate(spawnTrigger.GetSpawnManager().GetInitSpawn(_currentIndex).EnemiesObj, new Vector2(random, transform.position.y), Quaternion.identity);

    //             enemy.transform.SetParent(enemiesParent.transform);

    //             _onEnemySpawned?.Invoke();

    //             waveSlider.value++;
    //             _currentSpawn++;
    //             _currentDelaySpawn = 0f;
    //         }
    //         else if (_currentSpawn >= spawnTrigger.GetSpawnManager().GetInitSpawn(_currentIndex).AmountSpawn)
    //         {
    //             CanSpawn = false;

    //             _currentIndex++;
    //             _currentSpawn = 0;
    //             _currentDelaySpawn = 0f;
    //             _currentDelayStartSpawn = 0f;

    //             if (_currentIndex < spawnTrigger.GetSpawnManager().initializeSpawns.Length)
    //                 _delayStartSpawn = spawnTrigger.GetSpawnManager().GetInitSpawn(_currentIndex).DelayStartSpawn;
    //         }
    //     }
    //     else if (!CanSpawn)
    //     {
    //         _currentDelayStartSpawn += Time.deltaTime;

    //         if (_currentDelayStartSpawn > _delayStartSpawn)
    //             CanSpawn = true;
    //     }
    //     else if (_currentIndex >= spawnTrigger.GetSpawnManager().initializeSpawns.Length)
    //     {
    //         Debug.Log("Wave Finish");
    //         GameFinish = true;
    //     }
    // }
    #endregion
}
