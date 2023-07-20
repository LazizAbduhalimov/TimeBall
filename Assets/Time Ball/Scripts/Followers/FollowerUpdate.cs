using UnityEngine;

public class FollowerUpdate : Follower
{
    void Update()
    {
        Move(Time.deltaTime);
    }
}
