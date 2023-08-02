using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private FPSLimiter _fpsLimiter;
    [SerializeField] private BallContoller _ballConroller;

    private void Awake()
    {
        _fpsLimiter.Initialize();
        _ballConroller.Initialize();
    }
}
