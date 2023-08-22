using System;
using System.Threading;
using UnityEngine;

public abstract class ResourceSeller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Sell(player);
        }
    }


    public void Sell(Player player)
    {
        if(!TryFindBank(player, out IBank bank))
            return;

        var money = player.SpendResource(bank);

        player.AddMoney(money);
    }

    protected abstract bool TryFindBank(Player player, out IBank bank);
}
