using System;

public sealed class Bank<T> : IBank where T : IResource
{
    private int _count = 0;

    public int Count => _count;

    public bool TryAdd(IResource resource)
    {
        if (resource == null)
            return false;

        if (resource is not T)
            return false;

        if (resource.Count < 0)
            return false;

        _count += resource.Count;

        return true;
    }

    public void Spend(int value)
    {
        if(value < 0)
            throw new ArgumentException("Value isn't corretly");

        _count -= value;
    }
}