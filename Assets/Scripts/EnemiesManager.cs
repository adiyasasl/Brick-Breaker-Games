using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent _onEnemyRemoved;
    [SerializeField]
    private UnityEvent _onEnemyEmpty;

    private List<GameObject> enemies = new List<GameObject>();

    public void AddEnemy()
    {
        var enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var obj in enemy)
        {
            if (!enemies.Contains(obj))
            {
                enemies.Add(obj);
            }
        }
    }
    
    public void RemoveEnemy(GameObject gameObject)
    {
        enemies.Remove(gameObject);
        _onEnemyRemoved?.Invoke();

        if(enemies.Count == 0)
        {
            Debug.Log("Enemies is empty");
            _onEnemyEmpty?.Invoke();
        }
    }
}
