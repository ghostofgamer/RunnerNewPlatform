using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Damage { get; private set; } = 15;

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
