using Scripts.PlayerInput;
using System;
using UnityEngine;

public class ObjectInteractionController : MonoBehaviour
{
    [SerializeField] Transform objectHolder;
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    private void Start()
    {
        InputManager.OnPickup += HandlePickup;
    }
    private void Update()
    {
        if (heldObject != null)
            RecenterObject();
    }

    private void RecenterObject()
    {
        if (Vector3.Distance(heldObject.transform.position, objectHolder.position) > 0.01f)
        {
            var moveDirection = objectHolder.position - heldObject.transform.position;
            heldObjectRB.AddForce(moveDirection * pickupForce);
        }
    }

    private void HandlePickup()
    {
        if (heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                PickupObject(hit.transform.gameObject);
            }
        }
        else
        {
            DropObject();
        }
    }

    private void DropObject()
    {
        heldObjectRB.useGravity = true;
        heldObjectRB.drag = 1;
        heldObject.transform.parent = null;
        heldObject = null;
    }

    private void PickupObject(GameObject pickupObject)
    {
        InteractableObjectBase interactable;
        if (pickupObject.TryGetComponent<InteractableObjectBase>(out interactable))
        {
            heldObject = pickupObject;
            heldObjectRB = interactable.RigidBody;
            heldObjectRB.useGravity = false;
            heldObjectRB.drag = 10;
            heldObject.transform.parent = objectHolder.transform;
        }
    }
}
