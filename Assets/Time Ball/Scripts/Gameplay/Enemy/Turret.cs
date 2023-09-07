using UnityEngine;

public class Turret : EnemyBase
{
    [Header("Unique properties")]
    [SerializeField] private Transform _bulletCreateTransform;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _rotationSpeed;

    [Header("Pool settings")]
    [SerializeField] private CollisionEffectPool _bulletsPool;
    [SerializeField] private CollisionEffectPool _deathEffectPool;

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

    private bool TryAttack()
    {
        PassedAttackTime += Time.deltaTime;
        if (PassedAttackTime < AttackRate)
            return false;

        PassedAttackTime -= AttackRate;
        Attack();
        return true;
    }

    public override void Attack()
    {
        CreateBullet(_bulletCreateTransform.position, transform.rotation);
    }

    private void CreateBullet(Vector3 position, Quaternion rotation)
    {
        var createdBullet = _bulletsPool.Pool.GetFreeElement(false);
        createdBullet.transform.position = position;
        createdBullet.transform.rotation = rotation;
        createdBullet.gameObject.SetActive(true);
    }

    private void LookAtTarget(Transform target)
    {
        var direction = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, _rotationSpeed * Time.deltaTime);
    }

    public override void Die()
    {
        _deathEffectPool.CreateObject(transform.position);
        OnEnemyDieEvent?.Invoke(this);
        gameObject.SetActive(false);
    }
}
