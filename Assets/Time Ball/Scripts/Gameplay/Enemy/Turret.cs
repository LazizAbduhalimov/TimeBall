using LavkaRazrabotchika;
using UnityEngine;

public class Turret : EnemyBase
{
    [Header("Unique properties")]
    [SerializeField] private Transform _bulletCreateTransform;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _rotationSpeed;

    [Header("Pool settings")]
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Transform _container;

    private BarController _barController;
    private PoolMono<PoolObject> _pool;

    public void Start()
    {
        _pool = new PoolMono<PoolObject>(_bullet, _poolCount, _container);
        _pool.autoExpand = _autoExpand;

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
        CreateBullet(_bulletCreateTransform.position);
    }

    private bool TryAttack()
    {
        PassedAttackTime += Time.deltaTime;
        if (PassedAttackTime < AttackRate)
            return false;

        PassedAttackTime -= AttackRate;
        Attack();
        return true;
    }

    private void CreateBullet(Vector3 position)
    {
        var createdBullet = _pool.GetFreeElement();
        createdBullet.transform.position = position;
    }

    private void LookAtTarget(Transform target)
    {
        var direction = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, _rotationSpeed * Time.deltaTime);
    }
}
