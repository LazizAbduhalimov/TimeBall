using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowmotionEffect : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _volume;
    [SerializeField] private float _transitionTime = 1f;

    private ChromaticAberration _chromaticAberration;
    private Coroutine _slowmotionCoroutine;

    private float _passedTime;

    private void Start()
    {
        _volume.profile.TryGetSettings(out _chromaticAberration);   
    }

    private void OnEnable()
    {
        TimeManager.OnTimeSlowedEvent += DoSlowmotionEffect;
        TimeManager.OnTimeUnslowedEvent += UndoSlowmotionEffect;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeSlowedEvent -= DoSlowmotionEffect;
        TimeManager.OnTimeUnslowedEvent -= UndoSlowmotionEffect;
    }

    private void DoSlowmotionEffect()
    {
        Debug.Log("Slow");
        if (_slowmotionCoroutine != null)
            StopCoroutine(_slowmotionCoroutine);
        _slowmotionCoroutine = StartCoroutine(SlowmotionCoroutine(_transitionTime));
    }

    private void UndoSlowmotionEffect()
    {
        Debug.Log("Unslow");
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
