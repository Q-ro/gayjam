using Scripts.PlayerInput;
using System;
using UnityEngine;

namespace Scripts.Interaction
{
    public class InspectableObject : InteractableObjectBase
    {
        new InteractionTypes interactionType => InteractionTypes.Inspect;
        public float deltaRotationX;
        public float deltaRotationY;
        public float rotationSpeed;
        bool isInteracting = false;

        void Start()
        {
            InputManager.OnLookMovement += OnLookMovementPerformed;
        }

        private void OnLookMovementPerformed(Vector2 vector)
        {
            if (!isInteracting)
                return;
            deltaRotationX = vector.x;
            deltaRotationY = vector.y;

            this.transform.rotation = Quaternion.AngleAxis(deltaRotationX * rotationSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * rotationSpeed, transform.right) *
                this.transform.rotation;
        }

        public override void Interact()
        {
            isInteracting = !isInteracting;
        }
    }
}