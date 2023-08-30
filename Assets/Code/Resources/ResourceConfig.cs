using UnityEngine;

[CreateAssetMenu(fileName = "new ResorceConfig", menuName = "Gameplay/ResourceConfig")]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private Resource _prefab;

    public Sprite Sprite => _sprite;
    public ResourceType ResourceType => _resourceType;
    public Resource Prefab => _prefab;
}
