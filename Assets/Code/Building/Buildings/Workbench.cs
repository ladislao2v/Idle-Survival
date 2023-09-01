using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(ResourceFactory))]
public class Workbench : Building
{
    [SerializeField] private Recipe[] _recipes;
    [SerializeField] private UnityEvent _crafted;

    private ResourceFactory _resourceFactory;
    private WaitForSeconds _delay;
    private float _delayTime = 0.25f;

    private void Start()
    {
        _resourceFactory = GetComponent<ResourceFactory>();

        _delay = new WaitForSeconds(_delayTime);
    }

    protected override void Interact(Player player)
    {
        foreach (var recipe in _recipes)
        {
            if (recipe.CanBuy(player, out int resourceCount))
            {
                StartCoroutine(SpawnResources(player.transform, recipe, resourceCount));

                _crafted?.Invoke();
            }
        }
    }

    private IEnumerator SpawnResources(Transform player, Recipe recipe, int resourceCount)
    {
        for (int i = 0; i < resourceCount; i++)
        {
            _resourceFactory.SpawnResource(recipe.Config, player.position, transform.position);

            yield return _delay;
        }
    }
}