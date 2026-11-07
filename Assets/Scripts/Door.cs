using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public InventoryManager inventory;

    public string InteractionPrompt => _prompt;

    void Update()
    {
        /*
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryManager.UseKey())
            {
                Debug.Log("Door unlocked");
                Debug.Log("Keys: " + inventoryManager.GetKeyCount());

                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("You need a Key to open this door.");
            }
        }
        */
    }

    public bool Interact(Interactor interactor)
    {
        if(inventory == null)
            return false;
        
        if (inventory.UseKey())
        {
            Debug.Log("Door unlocked");
            Debug.Log("Keys: " + inventory.GetKeyCount());

            gameObject.SetActive(false);
            return true;
        }

        return false;
    }

    public bool HoldInteract(Interactor interactor)
    {
        return false;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E to unlock the door.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
    */


}