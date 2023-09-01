using UnityEngine;

[CreateAssetMenu(fileName = "new BuildingConfig", menuName = "Gameplay/BuildingConfig")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private Building _prefab;
    [SerializeField] private Requirement _requirement;

    public Building Prefab => _prefab;
    public Requirement Requirement => _requirement;
}
