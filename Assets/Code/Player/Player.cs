using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Wallet))]
public sealed class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _resourceCountChanged;
    [SerializeField] private UnityEvent<int> _moneyCountChanged;

    private IBank[] _banks;
    private Wallet _wallet;

    public IBank[] Banks => _banks;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
    }

    public void Init(params IBank[] banks)
    {
        _banks = banks;
    }

    public void AddMoney(int value)
    {
        _wallet.Add(value);

        _moneyCountChanged?.Invoke(_wallet.Money);
    }

    public void SpendMoney(int value)
    {
        _wallet.Spend(value);

        _moneyCountChanged?.Invoke(_wallet.Money);
    }

    public bool TryPutResource(IResource resource)
    {
        foreach (var bank in _banks)
        {
            if(bank.TryAdd(resource))
            {
                _resourceCountChanged?.Invoke(bank.Count);

                return true;
            }

        }

        return false;
    }

    public int SpendResource(IBank bank)
    {
        var count = bank.Count;

        bank.Spend(count);

        _resourceCountChanged?.Invoke(bank.Count);

        return count * 2;
    }
}
