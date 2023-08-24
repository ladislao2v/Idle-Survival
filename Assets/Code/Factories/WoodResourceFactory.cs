using NTC.Global.Pool;
using UnityEngine;

public sealed class WoodResourceFactory : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    [Header("Spawn Properties")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Quaternion _rotation = Quaternion.identity;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private Transform _parent;

    public void Spawn(Vector3 position)
    {
        var spawnPosition = position + _offset;

        var drop = NightPool.Spawn(_config.Prefab as Wood, spawnPosition, _rotation);

        drop.transform.localScale = _scale;
        drop.transform.parent = _parent;

        if(drop.TryGetComponent(out ResourceAnimator animator))
            animator.Jump(spawnPosition);
    }
}