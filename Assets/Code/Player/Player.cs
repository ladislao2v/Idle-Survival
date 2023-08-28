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

    public void Init(params IBank[] banks)
    {
        _storage.Init(banks);
    }

    public void AddMoney(int value)
    {
        _wallet.Add(value);
    }

    public void SpendMoney(int value)
    {
        _wallet.Spend(value);
    }

    public bool TryPutResource(IResource resource)
    {
        return _storage.TryPutResourses(resource);
    }

    public int SpendResource(IBank bank)
    {
        var count = bank.Count;

        bank.Spend(count);

        return count * 2;
    }
}
