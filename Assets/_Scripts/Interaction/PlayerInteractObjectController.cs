using Scripts.Interaction;
using Scripts.PlayerInput;
using System;
using UnityEngine;

public class PlayerInteractObjectController : MonoBehaviour
{
    public static Action OnInteractionStarted;

    [SerializeField] float pickupRange = 20f;
    bool isHoldingObject = false;

    private void Start()
    {
        InputManager.Interact += OnInteractPerformed;
        PlayerObjectPickupController.OnPickupPerformed += OnPickupPerformed;
    }

    private void OnPickupPerformed(bool holdingObject)
    {
        isHoldingObject = holdingObject;
    }

    private void OnInteractPerformed()
    {
        if (isHoldingObject)
            return;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
        {
            DoInteraction(hit.transform.gameObject);
        }
    }

    private void DoInteraction(GameObject interactableObject)
    {
        InteractableObjectBase interactable;
        if (interactableObject.TryGetComponent<InteractableObjectBase>(out interactable))
        {
            if (!interactable.IsInteractable)
                return;

            interactable.Interact();
            OnInteractionStarted?.Invoke();
        }
    }
}
