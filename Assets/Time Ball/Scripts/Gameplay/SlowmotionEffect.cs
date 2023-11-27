using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SlowmotionEffect : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private float _transitionTime = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float _maxIntensity;

    private ChromaticAberration _chromaticAberration;
    private TimeManager _timeManager;

    private bool _isInitialized = false;
    private float _defaultIntensity;

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

    public void Initialize(TimeManager timeManager)
    {
        _volume.profile.TryGet(out _chromaticAberration);   
        _defaultIntensity = _chromaticAberration.intensity.value;
        _timeManager = timeManager;
        _isInitialized = true;
        Subscribe();
    }

    private void Subscribe()
    {
        _timeManager.OnTimeSlowedEvent += DoSlowmotionEffect;
        _timeManager.OnTimeUnslowedEvent += UndoSlowmotionEffect;
    }

    private void Unsubscribe()
    {
        _timeManager.OnTimeSlowedEvent += DoSlowmotionEffect;
        _timeManager.OnTimeUnslowedEvent += UndoSlowmotionEffect;
    }

    private void DoSlowmotionEffect()
    {
        _chromaticAberration.intensity.value = _maxIntensity;
    }

    private void UndoSlowmotionEffect()
    {
        _chromaticAberration.intensity.value = _defaultIntensity;
    }
}
