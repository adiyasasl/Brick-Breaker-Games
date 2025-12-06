using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public void SpawnObj(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
