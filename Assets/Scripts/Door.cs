using UnityEngine;

public class Door : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryManager.UseKey())
            {
                Debug.Log("Door unlocked");

                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("You need a Key to open this door.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E to unlock the door.");
        }
    }

}