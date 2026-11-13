
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public AudioClip pickupSound;

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

                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position, .5f);
                }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemInRange = null;
        }
    }
}
