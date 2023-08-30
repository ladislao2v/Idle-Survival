using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ResourceFactory))]
public class Workbench : Building
{
    [SerializeField] private Recipe[] _recipes;
    [SerializeField] private UnityEvent _crafted;

    private ResourceFactory _resourceFactory;

    private void Start()
    {
        _resourceFactory = GetComponent<ResourceFactory>();
    }

    protected override void Interact(Player player)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.CanBuy(player))
            {
                _resourceFactory.SpawnResource(recipe.Config, player.transform.position, transform.position);

                _crafted?.Invoke();
            }
        }
    }
}