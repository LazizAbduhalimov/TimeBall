using UnityEngine;

public class BallEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectl;

    private void OnCollisionEnter(Collision collision)
    {
        var createdEffect = Instantiate(_effectl);
        createdEffect.transform.position = transform.position;
    }
}
