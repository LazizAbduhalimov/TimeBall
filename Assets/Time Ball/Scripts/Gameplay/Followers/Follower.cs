using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    public void Move(float deltaTime)
    {
        var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _speed * deltaTime);

        transform.position = nextPosition;
    }

    [ContextMenu("Set position as offset")]
    public void SetPositionAsoffset()
    {
        _offset = transform.position;
    }
}
