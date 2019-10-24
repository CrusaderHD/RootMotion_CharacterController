using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int inventorySpace = 20;

    #region InventorySingleton
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of Inventory found.");
            return;
        }

        instance = this;
    }

    #endregion
    
    //Check to see if the Inventory is being changed: Add/Remove/Use Item.
    public delegate void OnItemChanged();
    public OnItemChanged callOnItemChanged; //trigger this event to happen if a change is being made to the inventory.

    //Create a list of items.
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            //If we do not have enough inventory space to pickup and add item
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Not enough Inventory Space.");
                return false;
            }
            //If we have enough space, add item.
            items.Add(item);
            //Trigger to update Inventory UI
            if (callOnItemChanged != null)
            {
                callOnItemChanged.Invoke();
            }
        }

        return true;

    }

    public void Remove(Item item)
    {
        //If item is selected to be removed. 
        items.Remove(item);

        //Trigger to update Inventory UI
        if (callOnItemChanged != null)
        {
            callOnItemChanged.Invoke();
        }
    }

}
