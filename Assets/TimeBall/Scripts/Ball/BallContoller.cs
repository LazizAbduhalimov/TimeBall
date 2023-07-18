using UnityEngine;

public class BallContoller : MonoBehaviour, IControllable
{
    [SerializeField] private float _forcePower;
    
    private Rigidbody _rigidbody;

    public void Move(Vector3 direction)
    {
        Throw(direction);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Throw(Vector3 direction)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(direction * _forcePower, ForceMode.Impulse);
    }
}
