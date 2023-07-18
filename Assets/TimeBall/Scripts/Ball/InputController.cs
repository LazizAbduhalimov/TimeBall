using System;
using UnityEngine;

public class InputController: MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private TragectoryLineRenderer _tragectoryLine;
    private IControllable _controllable;
    private Vector3 _direction;

    private bool _dragEnded = true;
    private float _slowdownFactor = 0.05f;

    private void Start()
    {
        _controllable = GetComponent<IControllable>();
        _tragectoryLine = GetComponent<TragectoryLineRenderer>();
        
        if (_controllable == null)
            throw new NullReferenceException($"There is no IContollable in {gameObject.name}");
    }

    private void Update()
    {
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            _direction = new Vector3(_joystick.Vertical, 0, -_joystick.Horizontal);
            
            if (_dragEnded)
                TimeManager.DoSlowmotion(_slowdownFactor);

            _tragectoryLine.Activate();
            _tragectoryLine.SetDirection(_direction);
            _dragEnded = false;
        }
        else
        {
            if (!_dragEnded)
            {
                _controllable.Move(_direction);
                TimeManager.UndoSlowmotion();
                _tragectoryLine.Deactivate();
                _dragEnded = true;
            }
        }
    }
}
