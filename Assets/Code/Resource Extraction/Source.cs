using System.Collections.Generic;
using UnityEngine;

public abstract class Source : MonoBehaviour
{
    [SerializeField] private ResourceSourceConfig _config;

    [Header("Spawn properties")]
    [SerializeField] private float _height = 1f;
    [SerializeField] private Quaternion _rotation = Quaternion.identity;

    private Stack<State> _states = new();
    private State _currentState;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach(var state in _config.States)
        {
            var position = transform.position + new Vector3(0, _height, 0);
            var newState = Instantiate(state, position, _rotation, transform);

            newState.Hide();

            _states.Push(newState);
        }

        _currentState = _states.Pop();

        _currentState.Show();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Extracter player))
        {
            player.Extract(this);
        }
    }

    public bool TryChangeState()
    {
        _currentState.Hide();

        if(_states.TryPop(out _currentState))
        {
            _currentState.Show();

            return true;
        }

        DropResource(transform.position);

        return false;
    }

    protected abstract void DropResource(Vector3 position);
}