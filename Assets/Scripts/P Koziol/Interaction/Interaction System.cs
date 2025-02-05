using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    private float _maxInteractionDistance;

    void Update()
    {
        Ray interactionRay = new Ray(transform.position, transform.forward);
        if (!Physics.Raycast(interactionRay, out RaycastHit hit, _maxInteractionDistance)) //Raycast Check to see if the ray hit something
        {
            return;
        }
        if (hit.collider.gameObject.tag != "Interactable")
        {
            return;
        }
        Interactable interaction = hit.collider.gameObject.GetComponent<Interactable>();
        if (interaction == null)
        {
            Debug.LogError("Interaction System: Interactable Object Does Not Have a Devired Interactable Component");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction.Interact();
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            interaction.ScrollInteract(Input.mouseScrollDelta.y);
        }
    }
}
