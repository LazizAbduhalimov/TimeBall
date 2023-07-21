using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int _fpsLimit = 60;

    private void Awake()
    {
        Application.targetFrameRate = _fpsLimit;
    }
}
