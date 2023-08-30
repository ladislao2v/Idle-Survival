using System.Collections.Generic;
using UnityEngine;

public sealed class Boot : MonoBehaviour
{
    [SerializeField] private Follower _camera;

    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private Mover _mover;

    [Header("Input")]
    [SerializeField] UserInput _input;
    [SerializeField] private FloatingJoystick _floatingJoystick;

    [Header("Resources")]
    [SerializeField] private ResourceType[] _resources;

    private List<Bank> _banks = new List<Bank>();


    private void Start()
    {
        _camera.Init(_player);

        foreach (var type in _resources)
        {
            _banks.Add(new Bank(type));
        }

        _player.Init(_banks.ToArray());
        _input.Init(_floatingJoystick, _mover);
    }
}
