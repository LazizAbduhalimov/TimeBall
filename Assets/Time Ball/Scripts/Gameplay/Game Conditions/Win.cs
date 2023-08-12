using System;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Action OnVictoryEvent;

    [SerializeField] private Joystick _joystickToInenable;

    private EnemyNumberManager _enemyNumberManager;
    private TimeManager _timeManager;
    private bool _isInitialized = false;

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

    public void Initialize(EnemyNumberManager enemyNumberManager, TimeManager timeManager)
    {
        _enemyNumberManager = enemyNumberManager;
        _timeManager = timeManager;
        Subscribe();
        _isInitialized = true;
    }

    private void Subscribe() =>
        _enemyNumberManager.OnNoEnemyLeftEvent += OnNoEnemyLeft;

    private void Unsubscribe() =>
        _enemyNumberManager.OnNoEnemyLeftEvent -= OnNoEnemyLeft;

    private void OnNoEnemyLeft()
    {
        OnVictoryEvent?.Invoke();
        RemoveInputControllers();
        _timeManager.DoSlowmotion();
    }

    private void RemoveInputControllers()
    {
        _joystickToInenable.enabled = false;

        var inputControllers = FindObjectsOfType<InputController>();
        foreach (var controller in inputControllers)
            controller.enabled = false;
    }
}