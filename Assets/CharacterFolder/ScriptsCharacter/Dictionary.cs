using System.Collections.Generic;
using UnityEngine;

public class Dictionary
{
    Dictionary<Item, int> Collects = new Dictionary<Item, int>();
    private int index = 1;
    public void Collect(Item weapon)
    {
        Collects.Add(weapon, index++);
    }

    public void RemoveWeapon(Item weapon)
    {
        if (Collects.ContainsKey(weapon)) Collects.Remove(weapon);
    }

   
}
