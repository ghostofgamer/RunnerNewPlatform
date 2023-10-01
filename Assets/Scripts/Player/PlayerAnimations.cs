using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private const string _heal = "Heal";
    private const string _dead = "Dead";
    private const string _takeDamage = "TakeDamage";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void HealAnimation(bool flag)
    {
        _animator.SetBool(_heal, flag);
    }

    public void TakeDamageAnimation(bool flag)
    {
        _animator.SetBool(_takeDamage, flag);
    }

    public void DeadAnimation(bool flag)
    {
        _animator.SetBool(_dead, flag);
    }
}
