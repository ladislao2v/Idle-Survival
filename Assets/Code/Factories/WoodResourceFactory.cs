using UnityEngine;

public sealed class WoodResourceFactory : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;

    [Header("Spawn Properties")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Quaternion _rotation = Quaternion.identity;
    [SerializeField] private Vector3 _scale;

    public void Spawn(Vector3 position)
    {
        var drop = Instantiate(_config.Prefab as Wood, position + _offset, _rotation);

        drop.Init(Random.Range(_minCount, _maxCount));
        drop.transform.localScale = _scale;
    }
}