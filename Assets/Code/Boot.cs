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

    private Bank<Wood> _woodBank;
    private Bank<Rock> _rockBank;

    private void Start()
    {
        _camera.Init(_player);

        _woodBank = new();
        _rockBank = new();

        _player.Init(_woodBank, _rockBank);
        _input.Init(_floatingJoystick, _mover);
    }
}
