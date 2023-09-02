using LavkaRazrabotchika;
using UnityEngine;

public class CollisionEffectCreator : MonoBehaviour
{
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private PoolObject _effect;
    [SerializeField] private Transform _container;

    private PoolMono<PoolObject> _pool;

    private void Start()
    {
        _pool = new PoolMono<PoolObject>(_effect, _poolCount, _container);
        _pool.autoExpand = _autoExpand;
    }

    private void CreateEffect(Vector3 position)
    {
        var effect = _pool.GetFreeElement();
        effect.transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
            CreateEffect(transform.position);
    }
}