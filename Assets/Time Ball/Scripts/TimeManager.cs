using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public Action OnTimeStoppedEvent;
    public Action OnTimeSlowedEvent;
    public Action OnTimeUnslowedEvent;

    [SerializeField] private float _slowdownFactor = 0.05f;
    [SerializeField] private float _smoothing = 0.1f;
    [SerializeField] private const float _smoothingFactor = 10f;

    private Coroutine _coroutine;

    public void StopTime()
    {
        Time.timeScale = 0f;
        OnTimeStoppedEvent?.Invoke();
    }

    public void DoSlowmotion()
    {
        if (_coroutine != null)
            StopCoroutine( _coroutine );

        _coroutine = StartCoroutine(SlowmotionRoutine());
        OnTimeSlowedEvent?.Invoke();
    }

    public void UndoSlowmotion()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(UnslowmotionRoutine());
        OnTimeUnslowedEvent?.Invoke();
    }

    private IEnumerator SlowmotionRoutine()
    {
        var waitingTime = _smoothing / _smoothingFactor;
        var percentage = (1 - _slowdownFactor) / _smoothingFactor;
        var waitingRealTime = new WaitForSecondsRealtime(waitingTime);

        while (Time.timeScale >= _slowdownFactor)
        {
            Time.timeScale -= percentage;
            yield return waitingRealTime;
        }
    }

    private IEnumerator UnslowmotionRoutine()
    {
        var waitingTime = _smoothing / _smoothingFactor;
        var percentage = (1 - _slowdownFactor) / _smoothingFactor;
        var waitingRealTime = new WaitForSecondsRealtime(waitingTime);
        
        while (Time.timeScale < 1)
        {
            Time.timeScale += percentage;
            yield return waitingRealTime;
        }
    }
}

