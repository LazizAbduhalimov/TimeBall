using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public Action OnEnemyDieEvent;

    [SerializeField] protected int Health = 3;
    [SerializeField] protected float AttackRate;

    protected float PassedTimeBtwAttack;
}
