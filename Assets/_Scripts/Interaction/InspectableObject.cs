using Scripts.PlayerInput;
using UnityEngine;

namespace Scripts.Interaction
{
    public class InspectableObject : InteractableObjectBase
    {
        private bool isInteracting = false;
        private float deltaRotationX;
        private float deltaRotationY;


        protected override void Start()
        {
            base.Start();
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
            rigidBody.useGravity = !isInteracting;
            rigidBody.constraints = isInteracting ? RigidbodyConstraints.FreezePosition : RigidbodyConstraints.None;
            Physics.IgnoreLayerCollision(6, 3, isInteracting);
            var a = GameObject.FindWithTag("ObjectHolder");
            if (a != null)
                this.transform.position = a.transform.position;
        }
    }
}