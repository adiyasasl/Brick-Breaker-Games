using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    public List<Transform> Enemies = new List<Transform>();
    public float YMove = 1f;
    public void SetGridPosition()
    {
        Enemies.Clear();
        var enemy = GameObject.FindGameObjectsWithTag("Brick");

        foreach (var obj in enemy)
        {
            var transformPos = obj.GetComponent<Transform>();

            if (!Enemies.Contains(transformPos))
                Enemies.Add(transformPos);
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (i != Enemies.Count - 1)
                Enemies[i].DOMoveY(Enemies[i].position.y - YMove, 0.5f);
        }
    }
    
    public void DestroyGrid()
    {
        Invoke(nameof(StartDestroyGrid), 0.1f);
    }

    private void StartDestroyGrid()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] == null)
                Enemies.RemoveAt(i);
        }
    }
}
