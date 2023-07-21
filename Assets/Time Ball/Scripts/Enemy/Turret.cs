using System.Collections;
using UnityEngine;

public class Turret : EnemyBase
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletCreateTransform;

    [SerializeField] private Transform _rotationTarget;

    private void Start()
    {
        StartCoroutine(PeriodicAttackRoutine());
    }

    private void Update()
    {
        LookAtTarget(_rotationTarget);
    }

    public override void Attack()
    {
        CreateBullet();
    }

    private IEnumerator PeriodicAttackRoutine()
    {
        var waitingTime = new WaitForSeconds(AttackRate);

        while (true)
        {
            yield return waitingTime;
            Attack();
        }
    }

    private void CreateBullet()
    {
        var createdBullet = Instantiate(_bullet, _bulletCreateTransform.position, transform.rotation);
    }

    private void LookAtTarget(Transform target)
    {
        transform.LookAt(target);
    }
}
