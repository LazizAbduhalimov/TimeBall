using UnityEngine;

[RequireComponent(typeof(IControllable))]
public class InputController: MonoBehaviour
{
    public TimeManager TimeManager;

    [SerializeField] private Joystick _joystick;

    private TragectoryLineRenderer _tragectoryLine;
    private IControllable _controllable;
    private Vector3 _direction;

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

    public void Initialize(TimeManager timeManager)
    {
        TimeManager = timeManager;
        _controllable = GetComponent<IControllable>();
        _tragectoryLine = GetComponent<TragectoryLineRenderer>();
    }

    private void OnJoystickPointerDown()
    {
        TimeManager.DoSlowmotion();
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
