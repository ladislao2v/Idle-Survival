using UnityEngine;
using UnityEngine.Events;

public class Workbench : Building
{
    [SerializeField] private Recipe[] _recipes;
    [SerializeField] private UnityEvent _crafted;

    protected override void Interact(Player player)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.CanBuy(player, out int resourceCount))
            {
                StartCoroutine(player.SpawnResources(recipe.Config,
                    resourceCount,
                    player.transform,
                    transform));

                _crafted?.Invoke();
            }
        }
    }
}