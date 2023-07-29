using UnityEngine;

public class CameraFieldViewChanger : MonoBehaviour
{
    [SerializeField] private float _landscapeFieldOfView = 30f;
    [SerializeField] private float _portraitFieldOfView = 60f;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Screen.width > Screen.height)
            _camera.fieldOfView = _landscapeFieldOfView;
        else
            _camera.fieldOfView = _portraitFieldOfView;
    }
}
