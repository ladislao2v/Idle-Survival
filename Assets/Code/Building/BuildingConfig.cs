using UnityEngine;

[CreateAssetMenu(fileName = "new BuildingConfig", menuName = "Gameplay/BuildingConfig")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private Building _prefab;
    [SerializeField] private Requirement[] _requirements;

    public Building Prefab => _prefab;
    public Requirement[] Requirements => _requirements;
}
