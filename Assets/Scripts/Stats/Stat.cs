using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    //All of these are for when items are picked up and equipped utilizing the inventory Management system. 
    //Does not currently apply to the inplace character model as it comes created with Armor and Weapon.
    //However, this will make it easier when working with other type character/enemies. 
    private List<int> modifiers = new List<int>();

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }


}
