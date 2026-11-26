using UnityEngine;
using System.Collections;

public class BranchDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public PlayerMovement playerMovement;
    public AudioSource branchAudio;

    public float dialogueDelay = 1f;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            StartCoroutine(BranchSequence());
        }
    }

    IEnumerator BranchSequence()
    {
        playerMovement.isMovementLocked = true;
        branchAudio.Play();
        yield return new WaitForSeconds(dialogueDelay);
        dialogueManager.StartDialogue(
            new string[]
            {
                "I think something is here with me..."
            },
            true
        );
    }
}