using System;
using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private float _timeUntilSlowmotion = 0.1f;
    [SerializeField] private float _timeToShowUI = 0.3f;
    [SerializeField] private Joystick _joystickToInenable;
    [SerializeField] private GameObject _UIObjectToShow;

    private EnemyNumberManager _enemyNumberManager;
    private TimeManager _timeManager;
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
        Debug.Log("Win UI is showing");
        _joystickToInenable.enabled = false;
        RemoveInputControllers();
        DoActionAfterSeconds(_timeManager.DoSlowmotion, _timeUntilSlowmotion);
        DoActionAfterSeconds(ShowUI, _timeToShowUI);
    }

    private void ShowUI()
    {
        _UIObjectToShow.gameObject.SetActive(true);
    }

    private void DoActionAfterSeconds(Action action, float time)
    {
        StartCoroutine(DoActionAfterSecondsRoutine(action, time));
    }

    private IEnumerator DoActionAfterSecondsRoutine(Action action, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        action();
    }

    private void RemoveInputControllers()
    {
        var inputControllers = FindObjectsOfType<InputController>();
        foreach (var controller in inputControllers)
            controller.enabled = false;
    }
}
