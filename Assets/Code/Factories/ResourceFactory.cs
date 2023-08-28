using NTC.Global.Pool;
using UnityEngine;

public sealed class ResourceFactory : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    [Header("Spawn Properties")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private Transform _parent;

    public void Spawn(Vector3 position)
    {
        var spawnPosition = position + _offset;

        var drop = NightPool.Spawn(_config.Prefab, spawnPosition, _rotation);

        drop.transform.parent = _parent;

        if(drop.TryGetComponent(out ResourceAnimator animator))
            animator.Jump(spawnPosition);
    }
}