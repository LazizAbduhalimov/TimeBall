using UnityEngine;

public class Win : MonoBehaviour
{
    private EnemyNumberManager _enemyNumberManager;
    private bool _isInitialized = false;

    private void OnEnable()
    {
        if(_isInitialized )
            Subscribe();
    }

    private void OnDisable()
    {
        if(_isInitialized)
            Unsubscribe();
    }

    public void Initialize(EnemyNumberManager enemyNumberManager)
    {
        _enemyNumberManager = enemyNumberManager;
        _isInitialized = true;
        Subscribe();
    }

    private void Subscribe() =>
        _enemyNumberManager.OnNoEnemyLeftEvent += OnNoEnemyLeft;

    private void Unsubscribe() =>
        _enemyNumberManager.OnNoEnemyLeftEvent -= OnNoEnemyLeft;

    private void OnNoEnemyLeft()
    {
        Debug.Log("Win UI is showing");
        // TODO: Show victory UI
    }
}
