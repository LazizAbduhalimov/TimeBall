using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected Vector3 _direction;

    private void Update()
    {
        transform.Rotate(_direction * _speed, Space.World);
    }
}
