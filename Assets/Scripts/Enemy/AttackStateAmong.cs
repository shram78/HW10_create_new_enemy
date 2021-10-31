using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(Animator))]

public class AttackStateAmong : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;
    private string _animationAttack = "Attack";
    private ParticleSystem _shoot;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _shoot = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _shoot.Play();
        _animator.Play(_animationAttack);
        target.ApplyDamage(_damage);
    }
}
