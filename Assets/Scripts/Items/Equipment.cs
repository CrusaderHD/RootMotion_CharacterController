using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;

    public GameObject weaponPrefab;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        //Equip Item
        EquipmentManager.instance.EquipItem(this);
        //Remove Item from inventory
        RemoveFromInventory();
    }
}


public enum EquipmentSlot { Head, Chest, Legs, OneHandWeapon, TwoHandWeapon, Shield, Feet}
