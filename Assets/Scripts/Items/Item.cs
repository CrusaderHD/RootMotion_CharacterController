using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public string itemName = "New Item"; //Name of Item
    public Sprite icon = null;           //Image of Item
    public bool isDefaultItem = false;
    public GameObject itemPrefab;


    public virtual void Use()
    {
        //Use the Item.
       
        Debug.Log("Using: " + itemName);
    }

    //Remove Item from Inventory when being used.
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
