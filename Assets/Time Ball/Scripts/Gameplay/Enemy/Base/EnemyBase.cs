using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public Action<EnemyBase> OnEnemyDieEvent;

    [SerializeField] protected int Health = 3;
    [SerializeField] protected float AttackRate;
    [SerializeField] private ParticleSystem _deathEffect;

    protected float PassedAttackTime;

    public virtual void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage can't be less than 0");

        Health -= damage;

        if (Health <= 0)
            Die();
    }

    public virtual void Attack() { }

    public virtual void Die()
    {
        if (_deathEffect != null)
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
        OnEnemyDieEvent?.Invoke(this);
        gameObject.SetActive(false);
    }
}
