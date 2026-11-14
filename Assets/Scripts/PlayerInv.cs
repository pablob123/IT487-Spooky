
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public AudioClip pickupSound;
    public AudioSource pickupAudio;

    public ObjectiveManager objectiveManager;

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

                if (objectiveManager != null)
                {
                    objectiveManager.KeyCollected();
                }

                Debug.Log("Pickup sound triggered!");

                if (pickupAudio != null && pickupSound != null)
                {
                    pickupAudio.PlayOneShot(pickupSound);
                }
                else
                {
                    Debug.LogWarning("Pickup Audio or Pickup Sound is missing!");
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
