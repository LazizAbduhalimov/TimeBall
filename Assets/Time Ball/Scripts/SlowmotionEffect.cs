using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SlowmotionEffect : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private float _transitionTime = 1f;

    private ChromaticAberration _chromaticAberration;
    private Coroutine _slowmotionCoroutine;
    private TimeManager _timeManager;
    private float _passedTime;

    private void Awake()
    {
        _timeManager = FindObjectOfType<InputController>()._timeManager;
    }
    private void Start()
    {
        _volume.profile.TryGet(out _chromaticAberration);   
    }

    private void OnEnable()
    {
        _timeManager.OnTimeSlowedEvent += DoSlowmotionEffect;
        _timeManager.OnTimeUnslowedEvent += UndoSlowmotionEffect;
    }

    private void OnDisable()
    {
        _timeManager.OnTimeSlowedEvent -= DoSlowmotionEffect;
        _timeManager.OnTimeUnslowedEvent -= UndoSlowmotionEffect;
    }

    private void DoSlowmotionEffect()
    {
        if (_slowmotionCoroutine != null)
            StopCoroutine(_slowmotionCoroutine);
        _slowmotionCoroutine = StartCoroutine(SlowmotionCoroutine(_transitionTime));
    }

    private void UndoSlowmotionEffect()
    {
        if (_slowmotionCoroutine != null)
            StopCoroutine(_slowmotionCoroutine);
        _slowmotionCoroutine = StartCoroutine(UnSlowmotionCoroutine(_transitionTime));
    }

    private IEnumerator SlowmotionCoroutine(float duration)
    {
        var partWaitingTime = new WaitForSecondsRealtime(duration / 20f);
        while (_passedTime < duration)
        {
            _passedTime += partWaitingTime.waitTime;
            _chromaticAberration.intensity.value = _passedTime / duration;
            yield return partWaitingTime;
        }
    }

    private IEnumerator UnSlowmotionCoroutine(float duration)
    {
        var partWaitingTime = new WaitForSecondsRealtime(duration / 20f);
        while (_passedTime > 0)
        {
            _passedTime -= partWaitingTime.waitTime;
            _chromaticAberration.intensity.value = _passedTime / duration;
            yield return partWaitingTime;
        }
    }
}
