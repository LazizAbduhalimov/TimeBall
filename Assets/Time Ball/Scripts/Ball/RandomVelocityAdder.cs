using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BallContoller))]
public class RandomVelocityAdder : MonoBehaviour
{
    private BallContoller _ballContoller;
    private TimeManager _timeManager;

    private void Awake()
    {
        _ballContoller = GetComponent<BallContoller>();
    }

    private void Start()
    {
        StartCoroutine(AddRandomVelocity(-1, 1));
    }

    private IEnumerator AddRandomVelocity(float minValue, float maxValue)
    {
        while (true)
        {
            var rX = Random.Range(minValue, maxValue);
            var rZ = Random.Range(minValue, maxValue);

            var direction = new Vector3(rX, 0f, rZ);
            _ballContoller.Move(direction);
            yield return new WaitForSeconds(3f);
        }
    }

    private void PlaySlomotionEffect()
    {

    }
}
