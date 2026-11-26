using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    public float typingSpeed = 0.04f;

    public AudioSource typingAudio;
    public AudioClip typingSound;

    public PlayerMovement playerMovement;
    public Transform introWalk;
    public GameObject objectiveText;
    public float introDelay = 1f;

    public string[] openingDialogue =
    {
        "Did I drop my keys in the woods?",
        "Well, now I have to walk back."
    };

    private string[] currentDialogue;

    private bool lockMovement;

    private bool openingFinished = false;

    private int currentLine = 0;
    private bool isTyping = false;

    private Coroutine typingCoroutine;

    void Start()
    {
        dialoguePanel.SetActive(false);
        objectiveText.SetActive(false);

        playerMovement.isMovementLocked = true;

        StartCoroutine(OpeningSequence());
    }

    IEnumerator OpeningSequence()
    {
        yield return new WaitForSeconds(introDelay);

        playerMovement.autoWalkTarget = introWalk;
        playerMovement.isAutoWalking = true;

        while (playerMovement.isAutoWalking)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        StartDialogue(openingDialogue, true);
    }

    public void StartDialogue(string[] lines, bool freezePlayer = true)
    {
        if (dialoguePanel.activeSelf || lines == null || lines.Length == 0)
            return;

        currentDialogue = lines;
        currentLine = 0;
        lockMovement = freezePlayer;

        if (lockMovement)
            playerMovement.isMovementLocked = true;

        dialoguePanel.SetActive(true);

        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);

                dialogueText.text = currentDialogue[currentLine];
                isTyping = false;

                typingAudio.Stop();

                return;
            }

            currentLine++;

            if (currentLine < currentDialogue.Length)
            {
                typingCoroutine = StartCoroutine(TypeDialogue());
            }
            else
            {
                dialoguePanel.SetActive(false);

                if (!openingFinished)
                {
                    objectiveText.SetActive(true);
                    openingFinished = true;
                }

                if (lockMovement)
                    playerMovement.isMovementLocked = false;
            }
        }
    }

    IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in currentDialogue[currentLine])
        {
            dialogueText.text += letter;

            if (char.IsLetterOrDigit(letter))
            {
                typingAudio.PlayOneShot(typingSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}