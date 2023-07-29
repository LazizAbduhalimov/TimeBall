using System.Collections;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    private BallContoller _ball;
    private EnemyNumberManager _enemyNumberManager;

    private bool _isInitialized = false;

    public void Initialize(BallContoller ballContoller, EnemyNumberManager enemyNumberManager)
    {
        _ball = ballContoller;
        _enemyNumberManager = enemyNumberManager;
        _isInitialized = true;
        Subscribe();
    }

    private void OnEnable()
    {
        if (_isInitialized)
            Subscribe();
    }
        

    private void OnDisable()
    {
        if (_isInitialized)
            Unsubscribe();
    }

    private void Subscribe() =>
        _ball.OnBallDeathEvent += Restart;

    private void Unsubscribe() => 
        _ball.OnBallDeathEvent -= Restart;

    public void Restart()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        _ball.transform.position = _ball.transform.parent.position;
        _ball.transform.parent.gameObject.SetActive(true);
        _enemyNumberManager.ResetEnemies();
    }
}
