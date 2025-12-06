using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private List<Transform> _obj = new List<Transform>();
    private BrickGrid _brickGrid;

    void Start()
    {
        _brickGrid = FindObjectOfType<BrickGrid>();

        var child = GetComponentsInChildren<Transform>();

        foreach (var pos in child)
        {
            _obj.Add(pos);
        }
    }
    
    public void DeleteObject()
    {
        _obj.RemoveAt(0);
        _brickGrid.DestroyGrid();
        if (_obj.Count == 1)
            Destroy(gameObject);
    }
}
