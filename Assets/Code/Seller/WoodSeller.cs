using UnityEngine;

public class WoodSeller : ResourceSeller
{
    protected override bool TryFindBank(Player player, out IBank bank)
    {
        foreach(var resourceBank in player.Banks)
        {
            if(resourceBank is Bank<Wood>)
            {
                bank = resourceBank;
                return true;
            }
        }

        bank = null;

        return false;
    }
}
