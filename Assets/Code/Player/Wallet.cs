using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _moneyCountChanged;

    private int _money = 0;

    public int Money => _money;

    public void Add(int value)
    {
        if (value < 0)
            throw new System.ArgumentException("Value is not correctly");

        _money += value;

        _moneyCountChanged?.Invoke(_money);
    }

    public bool TrySpend(int value)
    {
        Debug.Log(value);

        if (value < 0 || value > _money)
        {
            return false;
        }

        _money -= value;

        _moneyCountChanged?.Invoke(_money);

        return true;
    }
}
