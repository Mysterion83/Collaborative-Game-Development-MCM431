using UnityEngine;

[RequireComponent (typeof(Camera))]
public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    private float _maxInteractionDistance;

    private void Update()
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
        Interactable[] interactions = hit.collider.gameObject.GetComponents<Interactable>();
        if (interactions == null)
        {
            Debug.LogError("Interaction System: Interactable Object Does Not Have a Devired Interactable Component", gameObject);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Interactable interaction in interactions)
            {
                interaction.Interact();
            }
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            foreach (Interactable interaction in interactions)
            {
                interaction.ScrollInteract(Input.mouseScrollDelta.y);
            }
        }
    }
}
