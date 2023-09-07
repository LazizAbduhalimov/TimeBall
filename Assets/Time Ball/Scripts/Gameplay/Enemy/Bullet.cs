using UnityEngine;
using LavkaRazrabotchika;
using System.Collections;

public class Bullet : PoolObject
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        SetVelocity();
        StartCoroutine(EnableTrailRenderer());
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
        _trailRenderer.emitting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<BallContoller>(out var controller))
            controller.Die();

        Instantiate(_collisionEffect, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }

    private void SetVelocity()
    {
        var cos = Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        var sin = Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);

        var direction = new Vector3(sin, 0, cos);

        _rigidbody.velocity = direction * _speed;
    }

    private IEnumerator EnableTrailRenderer()
    {
        yield return null;
        yield return null;
        _trailRenderer.emitting = true;
    }
}
