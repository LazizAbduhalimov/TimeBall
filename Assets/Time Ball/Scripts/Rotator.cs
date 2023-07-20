using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, _speed * Time.deltaTime, 0), Space.World);
    }
}
