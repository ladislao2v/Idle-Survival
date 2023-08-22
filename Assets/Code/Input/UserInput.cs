using UnityEngine;

public sealed class UserInput : MonoBehaviour
{
    private FloatingJoystick _joystick;
    private Mover _mover;
    private Vector3 _direction;

    public void Init(FloatingJoystick joystick, Mover mover)
    {
        _joystick = joystick;
        _mover = mover;
    }

    private void Update()
    {
        _direction = ReadDirection(_joystick.Direction);
    }

    private void FixedUpdate()
    {
        _mover.Move(_direction);
        _mover.Rotate(_direction);
    }
    
    private Vector3 ReadDirection(Vector2 direction)
    {
        var x = direction.x;
        var z = direction.y;

        return new Vector3(x, 0, z);
    }
}
