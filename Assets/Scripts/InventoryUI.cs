using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI!");
    }

}
