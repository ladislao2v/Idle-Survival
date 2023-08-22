using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new SourceConfig", menuName = "Gameplay/SourceConfig")]
public sealed class ResourceSourceConfig : ScriptableObject
{
    [Header("States")]
    [SerializeField] private List<State> _states;


    public IReadOnlyList<State> States => _states;
}
