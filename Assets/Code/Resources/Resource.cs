using UnityEngine;

[RequireComponent(typeof(ResourceAnimator))]
public class Resource : MonoBehaviour, IResource
{
    [SerializeField] private int _count = 1;

    private ResourceAnimator _animator;

    public int Count => _count;

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
