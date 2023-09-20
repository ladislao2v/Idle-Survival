using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Storage))]
[RequireComponent(typeof(ResourceFactory))]
public sealed class Player : MonoBehaviour
{
    private Storage _storage;
    private Wallet _wallet;
    private ResourceFactory _resourceFactory;
    private WaitForSeconds _delay = new WaitForSeconds(0.25f);

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _storage = GetComponent<Storage>();
        _resourceFactory = GetComponent<ResourceFactory>();
    }

    public void Init(Bank[] banks)
    {
        _storage.Init(banks);
    }

    public IEnumerator SpawnResources(ResourceConfig config, int resourceCount, Transform from, Transform to)
    {
        for (int i = 0; i < resourceCount; i++)
        {
            _resourceFactory.SpawnResource(config, from.position, to.position);

            yield return _delay;
        }
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

    public bool TryPutResource(ResourceType type, int value)
    {
        return _storage.TryPutResourses(type, value);
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
