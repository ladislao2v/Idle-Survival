using System;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Storage))]
public sealed class Player : MonoBehaviour
{
    private Storage _storage;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _storage = GetComponent<Storage>();
    }

    public void Init(Bank[] banks)
    {
        _storage.Init(banks);
    }

    public void AddMoney(int value)
    {
        _wallet.Add(value);
    }

    public bool TrySpendMoney(int value)
    {
        return _wallet.TrySpend(value);
    }

    public int GetCurrentMoney()
    {
        return _wallet.Money;
    }

    public bool TryPutResource(IResource resource)
    {
        return _storage.TryPutResourses(resource);
    }

    public bool TrySpendResource(ResourceType type, int value)
    {
        return _storage.TrySpendResource(type, value);
    }

    public int GetCurrentResourceCount(ResourceType type)
    {
        return _storage.GetCurrentResourceCount(type);
    }
}
