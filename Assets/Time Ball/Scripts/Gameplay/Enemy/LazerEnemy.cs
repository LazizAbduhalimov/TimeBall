using UnityEngine;

public class LazerEnemy : EnemyBase
{
    [Header("Unique properties")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _rayDistance;
    [SerializeField] private LineRenderer _lazer;

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        var direction = transform.TransformDirection(Vector3.forward);

        _lazer.SetPosition(1, direction * _rayDistance);
        if(Physics.Raycast(transform.position, direction, out var hit, _rayDistance))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
