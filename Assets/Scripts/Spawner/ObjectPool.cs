using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialization(GameObject[] prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            var index = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[index], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialization(GameObject prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out GameObject enemy)
    {
        var filter = _pool.Where(p => p.activeSelf == false&&p.TryGetComponent(out Enemy enemy));
        var randomIndex = Random.Range(0, filter.Count());
        enemy = filter.ElementAt(randomIndex);
        return enemy != null;
    }

    protected bool TryGetBonus(out GameObject bonus)
    {
        bonus = _pool.First(p => p.activeSelf == false && p.TryGetComponent(out HealBonus healBonus));
        return bonus != null;
    }
}
