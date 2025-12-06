using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Spawn", menuName = "Spawner/Wave", order = 1)]
public class WaveSpawn : ScriptableObject
{
    public string MessageBeforeSpawn = "Wave 1";
    public InitializeSpawn[] InitSpawns;

    public InitializeSpawn GetCurrentSpawn(int index)
    {
        if (index < InitSpawns.Length)
            return InitSpawns[index];

        Debug.Log("InitSpawn is out of range");
        return null;
    }
}
