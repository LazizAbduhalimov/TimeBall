using UnityEngine;

public class FollowerInstance : Follower
{
    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.position = _target.position + _offset;
    }
}
