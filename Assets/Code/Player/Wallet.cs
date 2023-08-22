using UnityEngine;

public class Wallet : MonoBehaviour
{
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
