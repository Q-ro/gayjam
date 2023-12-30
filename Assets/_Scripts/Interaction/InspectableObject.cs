using Scripts.PlayerInput;
using Scripts.PlayerMovement;
using Scripts.UI;
using System;
using UnityEngine;

namespace Scripts.Interaction
{
    public class InspectableObject : InteractableObjectBase
    {
        public static Action OnObjectWasInspected;

        [SerializeField] InspectableInfo inspectableInfo;

        private bool isInteracting = false;
        private float deltaRotationX;
        private float deltaRotationY;
        Vector3 initialPosition;
        private bool isMouseDragged;

        bool isPlayerSitted;

        protected override void Start()
        {
            base.Start();
            InputManager.OnLookMovement += OnLookMovementPerformed;
            InputManager.OnPlayerMouseHeldPerformed += OnPlayerMouseHeldPerformed;
            PlayerMovementController.OnLockPlayerMovementPerformed += OnLockedCharaterMovementStateChange;
            ChairInteractionController.OnInteractWithChair += OnPlayerInteractionWithChairPerformed;

        }

        private void OnLockedCharaterMovementStateChange(bool obj)
        {
            if (obj)
                return;

            if (isInteracting)
                StopInspectedObject();
        }

        private void OnDestroy()
        {
            InputManager.OnLookMovement -= OnLookMovementPerformed;
            InputManager.OnPlayerMouseHeldPerformed -= OnPlayerMouseHeldPerformed;
            ChairInteractionController.OnInteractWithChair -= OnPlayerInteractionWithChairPerformed;
        }

        private void OnPlayerMouseHeldPerformed(bool obj) => isMouseDragged = obj;
        private void OnPlayerInteractionWithChairPerformed(bool obj) => isPlayerSitted = obj;


        private void OnLookMovementPerformed(Vector2 vector)
        {
            if (!isInteracting || !isMouseDragged || !isPlayerSitted)
                return;

            deltaRotationX = vector.x;
            deltaRotationY = vector.y;

            this.transform.rotation = Quaternion.AngleAxis(deltaRotationX * rotationSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * rotationSpeed, transform.right) *
                this.transform.rotation;
        }

        public override void Interact()
        {
            if (!isPlayerSitted) return;

            PlayerInteractObjectController.OnInteractionStarted?.Invoke();
            isInteracting = !isInteracting;
            rigidBody.useGravity = !isInteracting;
            rigidBody.constraints = isInteracting ? RigidbodyConstraints.FreezePosition : RigidbodyConstraints.None;
            Physics.IgnoreLayerCollision(6, 3, isInteracting);

            if (isInteracting)
            {
                StartInspectingObject();
            }
            else
            {
                StopInspectedObject();
            }
        }

        private void StartInspectingObject()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            var inpectorHolder = GameObject.FindWithTag("ObjectInspectorHolder");
            if (inpectorHolder != null)
            {
                initialPosition = this.transform.position;
                this.transform.position = inpectorHolder.transform.position;
            }
            InspectedInfoDisplay.OnUpdateInfoDisplay?.Invoke(inspectableInfo);
            InspectedInfoDisplay.OnShowInfoDisplay?.Invoke(true);
        }

        private void StopInspectedObject()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.transform.position = initialPosition;
            InspectedInfoDisplay.OnShowInfoDisplay?.Invoke(false);
            OnObjectWasInspected?.Invoke();
        }

        public override void StartInteraction()
        {

        }

        public override void EndInteraction()
        {

        }
    }
}