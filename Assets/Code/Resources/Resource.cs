using UnityEngine;

[RequireComponent(typeof(ResourceAnimator))]
public class Resource : MonoBehaviour, IResource
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int _count = 1;

    private ResourceAnimator _animator;

    public int Count => _count;
    public ResourceType Type => _resourceType;

    private void Awake()
    {
        _animator = GetComponent<ResourceAnimator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if (player.TryPutResource(this))
                _animator.PickUp();
        }
    }
}
