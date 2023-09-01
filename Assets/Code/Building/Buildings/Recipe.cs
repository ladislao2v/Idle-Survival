using System;
using UnityEngine;

[Serializable]
public class Recipe
{
    [SerializeField] private ResourceConfig _resource;
    [SerializeField, Min(0)] private int _count;
    [SerializeField, Min(0)] private int _price;

    public ResourceConfig Config => _resource;

    public bool CanBuy(Player player, out int resourceCount)
    {
        resourceCount = player.GetCurrentResourceCount(_resource.ResourceType) / _count;

        if (resourceCount == 0)
            return false;

        if(player.TrySpendResource(_resource.ResourceType, _count * resourceCount))
        {
            player.AddMoney(_price * resourceCount);

            return true;
        }

        return false;
    }
}