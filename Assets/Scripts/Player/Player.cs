using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth { get; private set; }

    public event UnityAction<float> HealthChanged;
    public event UnityAction Dying;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
            Die();
    }

    public void AddHealth(float heal)
    {
        CurrentHealth += heal;
        HealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
    }

    private void Die()
    {
        GetComponent<PlayerAnimations>().DeadAnimation(true);
        Dying?.Invoke();
    }
}
