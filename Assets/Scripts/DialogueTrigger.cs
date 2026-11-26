using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public string[] dialogueLines;

    public bool freezePlayer = true;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            dialogueManager.StartDialogue(
                dialogueLines,
                freezePlayer
            );
        }
    }
}