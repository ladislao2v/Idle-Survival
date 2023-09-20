using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> _capacityChanged;
    [SerializeField] private UnityEvent<int>[] _resourceChangedEvents;
    [SerializeField] private int _maxCapacity;

    private int _currentCapacity = 0;
    private Bank[] _banks;
    private WaitForSeconds _delay = new WaitForSeconds(0.25f);

    public void Init(Bank[] banks)
    {
        foreach (var bank in banks)
            if (bank == null)
                throw new ArgumentNullException(nameof(bank));

        _banks = banks;

        if (_banks.Length != _resourceChangedEvents.Length)
            throw new Exception("You shoud add ResourceView to events array");

        _capacityChanged?.Invoke(_currentCapacity, _maxCapacity);
    }

    private bool CanFit(int count)
    {
        if (_currentCapacity + count <= _maxCapacity)
            return true;

        return false;
    }

    public bool TryPutResourses(IResource resource)
    {
        return TryPutResourses(resource.Type, resource.Count);
    }

    public bool TryPutResourses(ResourceType type, int value)
    {
        if (!CanFit(value))
            return false;

        for (int i = 0; i < _banks.Length; i++)
        {
            if (_banks[i].TryAdd(type, value))
            {
                StartCoroutine(SmoothIncrease(i, _banks[i].Count - value, _banks[i].Count));

                _currentCapacity += value;

                _capacityChanged?.Invoke(_currentCapacity, _maxCapacity);

                return true;
            }
        }

        return false;
    }

    public bool TrySpendResource(ResourceType type, int value)
    {
        if (value > _currentCapacity)
            return false;

        for (int i = 0; i < _banks.Length; i++)
        {
            if (_banks[i].TrySpend(type, value))
            {
                StartCoroutine(SmoothReduction(i, _banks[i].Count + value, _banks[i].Count));

                _currentCapacity -= value;

                _capacityChanged?.Invoke(_currentCapacity, _maxCapacity);

                return true;
            }
        }

        return false;
    }

    public int GetCurrentResourceCount(ResourceType type)
    {
        foreach (var bank in _banks)
        {
            if (bank.IsKeep(type))
                return bank.Count;
        }

        throw new ArgumentException($"Bank of {type} is not exist");
    }

    private IEnumerator SmoothIncrease(int i, int from, int to)
    {
        for (int j = from; j <= to; j++)
        {
            _resourceChangedEvents[i]?.Invoke(j);

            yield return _delay;
        } 
    }

    private IEnumerator SmoothReduction(int i, int from, int to)
    {
        for (int j = from; j >= to; j--)
        {
            _resourceChangedEvents[i]?.Invoke(j);

            yield return _delay;
        } 
    }
}
