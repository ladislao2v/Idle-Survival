using System;

public interface IBank
{
    public int Count { get; }

    public bool TryAdd(IResource resource);
    public void Spend(int value);
}
