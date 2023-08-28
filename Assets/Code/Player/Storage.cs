using System;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> _capacityChanged;
    [SerializeField] private UnityEvent<int>[] _resourceChangedEvents;
    [SerializeField] private int _maxCapacity;

    private int _currentCapacity = 0;
    private IBank[] _banks;
    
    public void Init(IBank[] banks)
    {
        foreach (var bank in banks)
            if (bank == null)
                throw new ArgumentNullException(nameof(bank));

        _banks = banks;

        if (_banks.Length != _resourceChangedEvents.Length)
            throw new System.Exception("You shoud add ResourceView to events array");

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
        if(!CanFit(resource.Count))
            return false;

        for(int i = 0; i < _banks.Length; i++)
        {
            if (_banks[i].TryAdd(resource))
            {
                _resourceChangedEvents[i]?.Invoke(_banks[i].Count);

                _currentCapacity += resource.Count;

                _capacityChanged?.Invoke(_currentCapacity, _maxCapacity);

                return true;
            }
        }

        return false;
    }
}
