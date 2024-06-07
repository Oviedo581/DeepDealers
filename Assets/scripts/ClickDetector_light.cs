using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    private Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    void OnMouseDown()
    {
        if (interactable != null)
        {
            interactable.OnInteract();
        }
    }
}
