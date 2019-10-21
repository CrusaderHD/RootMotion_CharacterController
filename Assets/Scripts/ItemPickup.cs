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
        Destroy(gameObject);
    }


}
