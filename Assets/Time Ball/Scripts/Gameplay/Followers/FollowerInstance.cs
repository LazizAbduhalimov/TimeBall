using UnityEngine;

public class FollowerInstance : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;


    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.position = _target.position + _offset;
    }

    [ContextMenu("Set position as offset")]
    public void SetPositionAsoffset()
    {
        _offset = transform.position;
    }
}
