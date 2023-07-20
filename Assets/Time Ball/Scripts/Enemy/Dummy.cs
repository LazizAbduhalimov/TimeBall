using System;
using UnityEngine;

public class Dummy : EnemyBase, IEnemy
{
    [SerializeField] private ParticleSystem _deathEffect;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage can't be less than 0");

        Health -= damage;

        if (Health <= 0)
            Die();
    }

    public void Attack() {}

    public void Die()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
        OnEnemyDieEvent?.Invoke();
        Destroy(gameObject);
    }
}
