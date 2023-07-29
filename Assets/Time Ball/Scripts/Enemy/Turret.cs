using UnityEngine;

public class Turret : EnemyBase
{
    [Header("Unique properties")]
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletCreateTransform;

    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _rotationSpeed;

    private BarController _barController;

    public void Start()
    {
        _barController = GetComponentInChildren<BarController>();
    }

    private void Update()
    {
        LookAtTarget(_rotationTarget);
        TryAttack();

        _barController.FillAmount = PassedAttackTime / AttackRate;
    }

    public override void Attack()
    {
        CreateBullet();
    }

    private void TryAttack()
    {
        PassedAttackTime += Time.deltaTime;
        if (PassedAttackTime > AttackRate)
        {
            PassedAttackTime -= AttackRate;
            Attack();
        }
    }

    private void CreateBullet()
    {
        var createdBullet = Instantiate(_bullet, _bulletCreateTransform.position, transform.rotation);
    }

    private void LookAtTarget(Transform target)
    {
        var direction = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, _rotationSpeed * Time.deltaTime);
    }
}
