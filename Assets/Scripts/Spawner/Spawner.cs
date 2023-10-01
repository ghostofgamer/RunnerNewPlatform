using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private HealBonus _bonusPrefab;
    [SerializeField] private float _timeToNextSpawn;
    [SerializeField] private float _timeToNextBonus;
    [SerializeField] private Transform _spawner;

    private Transform[] _points;

    private float _elapsedTime = 0f;
    private float _elapsedTimeToBonus = 0f;

    private void Start()
    {
        Initialization(_enemyPrefab);
        _points = new Transform[_spawner.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawner.GetChild(i);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToNextSpawn)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _elapsedTime = 0f;
                var randomIndex = Random.Range(0, _points.Length);
                SetEnemy(enemy, _points[randomIndex]);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Transform transform)
    {
        enemy.SetActive(true);
        enemy.transform.position = transform.position;
    }
}
