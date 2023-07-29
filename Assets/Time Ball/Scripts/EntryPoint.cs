using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private FPSLimiter _fpsLimiter;
    [SerializeField] private Restarter _restarter;
    [SerializeField] private Win _win;
    [SerializeField] private EnemyNumberManager _enemyNumberManager;
    [SerializeField] private BallContoller _ballConroller;
    [SerializeField] private InputController _inputController;
    [SerializeField] private SlowmotionEffect _slowMotionEffect;
    [SerializeField] private TimeManager _timeManager;

    private void Awake()
    {
        _fpsLimiter.Initialize();
        _ballConroller.Initialize();
        _enemyNumberManager.Initialize();
        _win.Initialize(_enemyNumberManager);
        _inputController.Initialize(_timeManager);
        _restarter.Initialize(_ballConroller, _enemyNumberManager);
        _slowMotionEffect.Initialize(_inputController.TimeManager);
    }
}
