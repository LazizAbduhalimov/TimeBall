using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallContoller : MonoBehaviour, IControllable
{
    public Action OnBallDeathEvent;
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Throw(direction.normalized);
    }

    public void Die()
    {
        _rigidbody.velocity = Vector3.zero;
        OnBallDeathEvent?.Invoke();
        Time.timeScale = 1f;
        transform.gameObject.SetActive(false);
    }

    private void Throw(Vector3 direction)
    {
        var newVelocity = direction * _speed;

        if (newVelocity.x != 0 || newVelocity.z != 0)
            _rigidbody.velocity = newVelocity;
    }
}
