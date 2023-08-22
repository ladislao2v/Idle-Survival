using UnityEngine;

public sealed class Boot : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private Mover _mover;

    [Header("Input")]
    [SerializeField] UserInput _input;
    [SerializeField] private FloatingJoystick _floatingJoystick;

    private Bank<Wood> _woodBank;

    private void Awake()
    {
        _woodBank = new();

        _player.Init(_woodBank);
        _input.Init(_floatingJoystick, _mover);
    }
}
