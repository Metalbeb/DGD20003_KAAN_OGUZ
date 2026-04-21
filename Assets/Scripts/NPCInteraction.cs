using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    public GameObject followCam;
    public GameObject closeUpCam;
    public UnityEvent onInteract;
    public string npcText = "△ ○ ▢";
    public ParticleSystem interactionVFX;

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    private bool playerInRange = false;
    private bool isTalking = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                ShowDialogue();
            }
            else
            {
                HideDialogue();
            }
        }
    }

    void Start()
    {
        Listener listener = GetComponent<Listener>();

        if (listener != null)
        {
            onInteract.AddListener(listener.React);
        }
    }

    public void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        dialogueText.text = npcText;

        if (interactionVFX != null)
        {
            interactionVFX.Play();
        }
        isTalking = true;
    }

    public void HideDialogue()
    {
        dialogueUI.SetActive(false);
        isTalking = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HideDialogue();
        }
    }
}