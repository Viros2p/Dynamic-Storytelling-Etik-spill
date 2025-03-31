using DialogueEditor;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    IInteractable interactableInRange = null; //Closest Interactable 
    public GameObejct InteractionIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context);//skal have tilføjet Unity Input system

    private void OnTriggerEnter2D(Collider2D Colission)
    {
        if (Colission.TryGetComponent(out IInteractable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            InteractionIcon.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D Colission)
    {
        if (Colission.TryGetComponent(out IInteractable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            InteractionIcon.SetActive(false);

        }
    }
}
