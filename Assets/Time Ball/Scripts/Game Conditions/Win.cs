using System;
using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private float _timeUntilSlowmotion = 0.1f;
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
        StartCoroutine(DoActionAfterSeconds(_timeManager.DoSlowmotion, _timeUntilSlowmotion));
        StartCoroutine(DoActionAfterSeconds(ShowUI, _timeUntilSlowmotion));
    }

    private void ShowUI()
    {
        _UIObjectToShow.gameObject.SetActive(true);
    }

    private IEnumerator DoActionAfterSeconds(Action action, float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        action();
    }

    private void RemoveInputControllers()
    {
        var inputControllers = FindObjectsOfType<InputController>();
        foreach (var controller in inputControllers)
            controller.enabled = false;
    }
}
