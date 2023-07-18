using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        transform.position = _target.transform.position;
    }
}
