using UnityEngine;

public sealed class Wood : MonoBehaviour, IResource
{
    private int _count;

    public int Count => _count;

    public void Init(int count)
    {
        _count = count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if (player.TryPutResource(this))
                gameObject.SetActive(false);
        }
    }
}
