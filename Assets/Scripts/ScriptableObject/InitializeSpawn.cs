using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Init Spawn", menuName = "Spawner/Init", order = 2)]
public class InitializeSpawn : ScriptableObject
{
    public float DelayBeforeSpawn = 10f;
    public GameObject EnemiesObj;
}
