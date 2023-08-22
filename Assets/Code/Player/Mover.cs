using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public sealed class Mover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed = 10f;
    [SerializeField] private UnityEvent<bool> _moved;

    [Header("Ground Check")]
    [SerializeField] private Transform _foot;
    [SerializeField, Min(0f)] private float _rayDistance = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private Vector3 LimitPosition(Vector3 position)
    {
        if(Physics.Raycast(_foot.position, -_foot.up, _rayDistance))
        {
            _lastPosition = transform.position;

            return position;
        }

        return _lastPosition;
    }

    public void Move(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            _moved?.Invoke(false);
            return;
        }

        var velocity = direction * _speed * Time.fixedDeltaTime;
        var newPosition = LimitPosition(_rigidbody.position + velocity);

        _moved?.Invoke(true);

        _rigidbody.MovePosition(newPosition);
    }

    public void Rotate(Vector3 direction)
    {
        transform.LookAt(_rigidbody.position + direction);
    }
}
