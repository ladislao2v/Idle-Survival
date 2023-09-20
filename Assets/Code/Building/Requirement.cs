using System;
using UnityEngine;

[Serializable]
public class Requirement
{
    [SerializeField] private ResourceConfig _resource;
    [SerializeField] private int _count;

    public Sprite Sprite => _resource.Sprite;
    public ResourceType ResourceType => _resource.ResourceType;
    public ResourceConfig Config => _resource;
    public int Count => _count;

    public bool TryGrant(Player player)
    {
        return player.TrySpendResource(_resource.ResourceType, _count);
    }
}
