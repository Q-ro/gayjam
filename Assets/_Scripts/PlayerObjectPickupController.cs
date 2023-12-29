using Scripts.PlayerInput;
using System;
using UnityEngine;

namespace Scripts.Interaction
{
    public class PlayerObjectPickupController : MonoBehaviour
    {
        public static Action<bool> OnPickupPerformed;

        [SerializeField] Transform objectHolder;
        [SerializeField] private float pickupRange = 5.0f;
        [SerializeField] private float pickupForce = 150.0f;

        private GameObject heldObject;
        private Rigidbody heldObjectRB;
        bool isInteracting = false;

        private void Start()
        {
            InputManager.OnPickup += HandlePickup;
            PlayerInteractObjectController.OnInteractionStarted += OnInteractionStarted;
        }

        private void OnDestroy()
        {
            InputManager.OnPickup -= HandlePickup;
            PlayerInteractObjectController.OnInteractionStarted -= OnInteractionStarted;
        }

        private void OnInteractionStarted()
        {
            isInteracting = !isInteracting;
        }

        private void Update()
        {
            if (heldObject != null)
                RecenterObject();
        }

        private void RecenterObject()
        {
            if (Vector3.Distance(heldObject.transform.position, objectHolder.position) > 0.15f)
            {
                var moveDirection = objectHolder.position - heldObject.transform.position;
                heldObjectRB.AddForce(moveDirection * pickupForce);
            }
        }

        private void HandlePickup()
        {
            if (isInteracting)
                return;

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

            OnPickupPerformed?.Invoke(heldObject != null);
        }

        private void DropObject()
        {
            heldObjectRB.useGravity = true;
            heldObjectRB.freezeRotation = false;
            heldObjectRB.drag = 1;
            heldObject.transform.parent = null;
            heldObject = null;
            Physics.IgnoreLayerCollision(6, 3, false);
        }

        private void PickupObject(GameObject pickupObject)
        {
            InteractableObjectBase interactable;
            if (pickupObject.TryGetComponent<InteractableObjectBase>(out interactable))
            {
                heldObject = pickupObject;
                heldObjectRB = interactable.RigidBody;
                heldObjectRB.useGravity = false;
                heldObjectRB.freezeRotation = true;
                heldObjectRB.drag = 20;
                Physics.IgnoreLayerCollision(6, 3, true);


            }
        }


    }
}
