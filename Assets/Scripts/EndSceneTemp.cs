using UnityEngine;

public class EndSceneTemp : MonoBehaviour
{
    public InventoryManager inventory;
    public GameObject endPanel;
    public GameObject Enemy;
    [SerializeField] private string _prompt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
        if (inventory == null)
            return false;

        if (inventory.UseKey())
        {
            Debug.Log("E");
            endPanel.SetActive(true);
            Enemy.SetActive(false);

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

