using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                NPCInteraction npc = hit.collider.GetComponent<NPCInteraction>();

                if (npc != null)
                {
                    npc.ShowDialogue();
                }
            }
        }
    }
}