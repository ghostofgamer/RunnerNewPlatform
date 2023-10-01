using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private float _timeToNextSpawn;
    [SerializeField] private float _timeToNextBonus;
    [SerializeField] private Transform _spawner;
    [SerializeField] private int _capacity;

    private Transform[] _points;

    private float _elapsedTime = 0f;
    private float _elapsedTimeToBonus = 0f;

    private void Start()
    {
        Initialization(_bonusPrefab, _capacity);
        Initialization(_enemyPrefab, _capacity);
        _points = new Transform[_spawner.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawner.GetChild(i);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _elapsedTimeToBonus += Time.deltaTime;

        if (_elapsedTimeToBonus < _timeToNextBonus)
        {
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
        else
        {
            if (TryGetBonus(out GameObject bonus))
            {
                _elapsedTimeToBonus = 0f;
                _elapsedTime = 0f;
                var randomIndex = Random.Range(0, _points.Length);
                SetEnemy(bonus, _points[randomIndex]);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Transform transform)
    {
        enemy.SetActive(true);
        enemy.transform.position = transform.position;
    }
}
