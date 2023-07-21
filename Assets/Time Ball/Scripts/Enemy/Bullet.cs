using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private float _forcePower;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        var cos = Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        var sin = Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);

        var direction = new Vector3(sin, 0, cos);

        _rigidbody.velocity = direction * _forcePower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<BallContoller>(out var controller))
            controller.Die();

        Instantiate(_collisionEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }   
}
