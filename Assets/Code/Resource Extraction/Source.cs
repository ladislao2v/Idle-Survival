using NTC.Global.Pool;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ResourceFactory))]
public class Source : MonoBehaviour
{
    [SerializeField] private ResourceSourceConfig _config;
    [SerializeField] private UnityEvent _stateChanged;
    [SerializeField] private UnityEvent _broked;

    [Header("Spawn properties")]
    [SerializeField] private float _rechargeTime;
    [SerializeField] private float _height = 1f;
    [SerializeField] private Quaternion _rotation = Quaternion.identity;

    [Header("Tool")]
    [SerializeField] private ToolType _type;

    private Stack<State> _states = new();
    private State _currentState;
    private Collider _collider;
    private ResourceFactory _factory;

    public ToolType Type => _type;

    private void Start()
    {
        _factory = GetComponent<ResourceFactory>();
        _collider = GetComponent<Collider>();

        Spawn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Extracter player))
        {
            player.Extract(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Extracter player))
        {
            player.StopExtract();
        }
    }

    private void Enable()
    {
        _collider.enabled = true;
    }

    private void Disable()
    {
        _collider.enabled = false;
    }

    private void Spawn()
    {
        if (_currentState)
            _currentState.Destroy();

        foreach (var state in _config.States)
        {
            var position = transform.position + new Vector3(0, _height, 0);
            var newState = NightPool.Spawn(state, position, _rotation);
            newState.transform.parent = transform;

            newState.Hide();

            _states.Push(newState);
        }

        _currentState = _states.Pop();

        _currentState.GrowUp();
        _currentState.Show();


        Enable();
    }

    private void DropResource(Vector3 position)
    {
        _factory.Spawn(position);
    }

    public bool TryChangeState()
    {
        if (_states.Count == 0)
            return false;

        _currentState.Destroy();

        if (_states.Count > 1)
        {
            _currentState = _states.Pop();
            _currentState.Show();

            _stateChanged?.Invoke();

            DropResource(transform.position);

            return true;
        }

        if(_states.TryPop(out _currentState))
            _currentState.Show();

        DropResource(transform.position);

        _broked?.Invoke();

        Disable();

        Invoke(nameof(Spawn), _rechargeTime);

        return false;
    }
}