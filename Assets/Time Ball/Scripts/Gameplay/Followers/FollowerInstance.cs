using UnityEngine;

public class FollowerInstance : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.position = _target.position;
    }
}
