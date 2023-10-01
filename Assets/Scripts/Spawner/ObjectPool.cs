using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialization(GameObject[] prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var index = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[index], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out GameObject result)
    {
        var filter = _pool.Where(p => p.activeSelf == false);
        var randomIndex = Random.Range(0, filter.Count());
        result = filter.ElementAt(randomIndex);
        return result != null;
    }
}
