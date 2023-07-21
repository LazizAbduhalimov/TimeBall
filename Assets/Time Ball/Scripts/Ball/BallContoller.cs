using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallContoller : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Throw(direction.normalized);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void Throw(Vector3 direction)
    {
        var newVelocity = direction * _speed;

        if (newVelocity.x != 0 || newVelocity.z != 0)
            _rigidbody.velocity = newVelocity;
    }
}
