using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region SingletonEquipmentManager

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    private Equipment[] currentEquipment;

    public Transform itemLocation;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);

    public OnEquipmentChanged onEquipmentChanged;

    private Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        //Initialize the Equipment
        int numEquipmentSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numEquipmentSlots];

    }


    //Equipping Items.
    public void EquipItem(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipmentSlot;

        Equipment oldItem = null;

        //Swap equipped item w/ item from inventory.
        if (currentEquipment[slotIndex] != null)
        {
            //Add currently equipped item back into inventory and swap with new item.
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        GameObject go = (GameObject) Instantiate(newItem.weaponPrefab, itemLocation.position, Quaternion.identity) as GameObject;
        go.transform.parent = itemLocation;
        Debug.Log("We are Equipping: " + newItem);


    }

    public void UnequipItem(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItemEquipment = currentEquipment[slotIndex];
            inventory.Add(oldItemEquipment);
            //Once unequipped reset that equipment slot to null. 
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItemEquipment);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnequipItem(i);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
            //TODO: Change this to unequip chosen item.
        }
    }
}
