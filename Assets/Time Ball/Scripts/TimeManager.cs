using System;
using UnityEngine;

public static class TimeManager
{
    public static Action OnTimeSlowedEvent;
    public static Action OnTimeUnslowedEvent;

    public static void DoSlowmotion(float _slowdownFactor)
    {
        Time.timeScale = _slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * Time.fixedUnscaledDeltaTime;
        OnTimeSlowedEvent?.Invoke();
    }

    public static void UndoSlowmotion()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
        OnTimeUnslowedEvent?.Invoke();
    }
}

