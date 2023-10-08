using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BallContoller))]
public class RandomVelocityAdder : MonoBehaviour
{
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private float _slowmotionDuration = 0.1f;
     
    private BallContoller _ballContoller;

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

            _timeManager.DoSlowmotion();
            yield return new WaitForSeconds(_slowmotionDuration);
            _timeManager.UndoSlowmotion();

            var direction = new Vector3(rX, 0f, rZ);
            _ballContoller.Move(direction);
            yield return new WaitForSeconds(3f);
        }
    }
}
