using UnityEngine;

[RequireComponent(typeof(ResourceAnimation))]
public sealed class Wood : MonoBehaviour, IResource
{
    [SerializeField] private int _count = 1;

    private ResourceAnimation _animation;

    public int Count => _count;

    private void Start()
    {
        _animation = GetComponent<ResourceAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if (player.TryPutResource(this))
                _animation.StartMoveAnimation();
        }
    }
}
