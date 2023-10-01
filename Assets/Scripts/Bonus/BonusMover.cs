using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMover : MonoBehaviour
{
    private float _speed = 15f;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
