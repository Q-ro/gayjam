using Scripts.Interaction;
using Scripts.PlayerInput;
using Scripts.PlayerMovement;
using System;
using UnityEngine;

public class PlayerInteractObjectController : MonoBehaviour
{
    public static Action<bool> IsInteractionStarted;

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
        if(gameObject.layer == 7){
            if (heldInteractableObject == null)
            {
                if (interactableObject.TryGetComponent<InteractableObjectBase>(out heldInteractableObject))
                {
                    if (!heldInteractableObject.IsInteractable)
                        return;
                    //heldInteractableObject = heldInteractableObject;
                    heldInteractableObject.Interact();
                    heldInteractableObject.StartInteraction();
                    //OnInteractionStarted?.Invoke();
                }
            }
            else
            {
                heldInteractableObject.Interact();
                heldInteractableObject.EndInteraction();
                heldInteractableObject = null;
            }
        } else {
            var interactableScript = interactableObject.GetComponent<InteractableObjectBase>();
            if(interactableScript != null && interactableScript.IsInteractable){
                interactableScript.Interact();
                interactableScript.StartInteraction();
            }
        }
        
    }
}
