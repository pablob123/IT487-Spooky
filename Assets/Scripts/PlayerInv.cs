using System.Collections.Generic;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{

    public InventoryManager inventoryManager;

    private GameObject itemInRange = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemInRange != null)
        {
            string itemName = itemInRange.name;

            if (itemName == "Key")
            {
                inventoryManager.AddKey(1);
                Debug.Log("Keys: " + inventoryManager.GetKeyCount());
            }

            itemInRange.SetActive(false);
            itemInRange = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemInRange = collision.gameObject;
            Debug.Log("Press E to interact");
        }
    }


}