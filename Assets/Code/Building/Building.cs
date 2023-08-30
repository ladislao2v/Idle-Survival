using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected abstract void Interact(Player player);

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Interact(player);
        }
    }
}
