using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
