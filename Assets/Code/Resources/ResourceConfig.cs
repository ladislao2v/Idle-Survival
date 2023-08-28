using UnityEngine;

[CreateAssetMenu(fileName = "new ResorceConfig", menuName = "Gameplay/ResourceConfig")]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _prefab;

    private Resource _resourcePrefab;

    private void OnValidate()
    {
        if(_prefab == null)
            return;

        if(!_prefab.TryGetComponent(out Resource resource))
            _prefab = null;
        else
            _resourcePrefab = resource;
    }

    public Sprite Sprite => _sprite;
    public Resource Prefab => _resourcePrefab;
}
