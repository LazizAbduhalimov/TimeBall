using UnityEngine;

public class BallEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
            Instantiate(_effect, transform.position, Quaternion.identity);
    }
}
