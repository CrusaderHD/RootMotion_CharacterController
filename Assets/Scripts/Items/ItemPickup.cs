using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking Up: " + item.itemName);
        //Add Item to Inventory and remove from scene.
        bool wasPickedUp = Inventory.instance.Add(item);

        //If item was able to be picked up and added to inventory, destroy Game Object from scene.
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }


}
