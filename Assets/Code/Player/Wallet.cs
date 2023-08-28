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
    }

    public void Spend(int value)
    {
        if (value < 0 && value > _money)
            throw new System.ArgumentException("Value is not correctly");

        _money -= value;
    }
}
