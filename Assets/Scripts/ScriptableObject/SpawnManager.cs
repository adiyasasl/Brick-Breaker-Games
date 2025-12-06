using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Manager", menuName = "Spawner/Manager", order = 0)]
public class SpawnManager : ScriptableObject
{
    public WaveSpawn[] WaveSpawns;

    public WaveSpawn GetWaveSpawn(int index)
    {
        if (index < WaveSpawns.Length)
            return WaveSpawns[index];

        Debug.Log("WaveSpawns is Out of Range");
        return null;
    }
}
