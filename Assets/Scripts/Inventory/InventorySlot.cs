using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    private Item item;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        //Setting the new item added to the inventory as an item.
        item = newItem;
        //Display the corresponding icon with the new item in the inventory.
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        //Set item = to null.
        item = null;

        //Set icon image to null and disable the icon.
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void RemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
