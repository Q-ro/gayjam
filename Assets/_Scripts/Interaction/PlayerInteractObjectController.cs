using Scripts.Interaction;
using Scripts.PlayerInput;
using Scripts.PlayerMovement;
using System;
using UnityEngine;

public class PlayerInteractObjectController : MonoBehaviour
{
    public static Action OnInteractionStarted;

    [SerializeField] float pickupRange = 20f;
    bool isHoldingObject = false;
    InteractableObjectBase heldInteractableObject;

    private void Start()
    {
        InputManager.OnInteract += OnInteractPerformed;        
        PlayerObjectPickupController.OnPickupPerformed += OnPickupPerformed;
    }


    private void OnDestroy()
    {
        InputManager.OnInteract -= OnInteractPerformed;
        PlayerObjectPickupController.OnPickupPerformed -= OnPickupPerformed;
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
        //InteractableObjectBase interactable;
        if (heldInteractableObject == null)
        {
            if (interactableObject.TryGetComponent<InteractableObjectBase>(out heldInteractableObject))
            {
                if (!heldInteractableObject.IsInteractable)
                    return;
                //heldInteractableObject = heldInteractableObject;
                heldInteractableObject.Interact();
                //OnInteractionStarted?.Invoke();
            }
        }
        else
        {
            heldInteractableObject.Interact();
            heldInteractableObject = null;
        }
    }
}
