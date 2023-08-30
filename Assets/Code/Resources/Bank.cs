using System;

public sealed class Bank
{
    private ResourceType _resourceType;
    private int _count = 0;

    public int Count => _count;

    public Bank(ResourceType resourceType)
    {
        _resourceType = resourceType;
    }

    public bool IsKeep(ResourceType type) => _resourceType == type;

    public bool TryAdd(IResource resource)
    {
        if (resource.Type != _resourceType)
            return false;

        if (resource.Count < 0)
            return false;

        _count += resource.Count;

        return true;
    }

    public bool TrySpend(ResourceType type, int value)
    {
        if(type != _resourceType)
            return false;

        if(value > _count)
            return false;

        if(value < 0)
            throw new ArgumentException("Value isn't corretly");

        _count -= value;

        return true;
    }
}