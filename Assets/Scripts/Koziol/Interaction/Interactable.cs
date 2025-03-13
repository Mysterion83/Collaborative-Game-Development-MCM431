using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();
    public abstract void ScrollInteract(float mouseScrollDelta);

    [SerializeField]
    public string TooltipText = "[E] Interact";
}