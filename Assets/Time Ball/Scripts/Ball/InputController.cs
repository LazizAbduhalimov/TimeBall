using System;
using UnityEngine;

public class InputController: MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private TragectoryLineRenderer _tragectoryLine;
    private IControllable _controllable;
    private Vector3 _direction;

    private float _slowdownFactor = 0.05f;

    private void OnEnable()
    {
        _joystick.OnPoinerDownEvent += OnJoystickPointerDown;
        _joystick.OnPoinerDragEvent += OnJoystickPointerDrag;
        _joystick.OnPoinerUpEvent += OnJoystickPointerUp;
    }

    private void OnDisable()
    {
        _joystick.OnPoinerDownEvent -= OnJoystickPointerDown;
        _joystick.OnPoinerDragEvent -= OnJoystickPointerDrag;
        _joystick.OnPoinerUpEvent -= OnJoystickPointerUp;
    }

    private void Start()
    {
        _controllable = GetComponent<IControllable>();
        _tragectoryLine = GetComponent<TragectoryLineRenderer>();
        
        if (_controllable == null)
            throw new NullReferenceException($"There is no IContollable in {gameObject.name}");
    }

    private void OnJoystickPointerDown()
    {
        TimeManager.DoSlowmotion(_slowdownFactor);
        _tragectoryLine.Activate();
    }

    private void OnJoystickPointerDrag()
    {
        _direction = new Vector3(-_joystick.Vertical, 0, _joystick.Horizontal);
        _tragectoryLine.SetDirection(_direction.normalized);
    }

    private void OnJoystickPointerUp()
    {
        _controllable.Move(_direction);
        TimeManager.UndoSlowmotion();
        _tragectoryLine.Deactivate();
    }
}
