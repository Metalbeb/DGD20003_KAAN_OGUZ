using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    public GameObject followCam;
    public GameObject closeUpCam;
    public UnityEvent onInteract;
    public string npcText = "△ ○ ▢";
    [SerializeField] private ParticleSystem interactionVFX;

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    public GameObject winScreen;

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
        if (onInteract == null)
        {
            onInteract = new UnityEvent();
        }
    }



    public void ShowDialogue()
    {
        Debug.Log("show");
        onInteract.Invoke();
        dialogueUI.SetActive(true);
        dialogueText.text = npcText;

        winScreen.SetActive(true);

        if (interactionVFX != null)
        {
            interactionVFX.Play();
        }
        else
        {
            Debug.Log("interactionVFX is null");

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