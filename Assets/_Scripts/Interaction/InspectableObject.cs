using Scripts.PlayerInput;
using UnityEngine;

namespace Scripts.Interaction
{
    public class InspectableObject : InteractableObjectBase
    {
        private bool isInteracting = false;
        private float deltaRotationX;
        private float deltaRotationY;
        Vector3 initialPosition;

        bool isPlayerSitted;

        protected override void Start()
        {
            base.Start();
            InputManager.OnLookMovement += OnLookMovementPerformed;
            ChairInteractionController.OnInteractWithChair += OnPlayerInteractionWithChairPerformed;
        }

        private void OnPlayerInteractionWithChairPerformed(bool obj)
        {
            isPlayerSitted = obj;
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
            if (!isPlayerSitted) return;
            PlayerInteractObjectController.OnInteractionStarted?.Invoke();
            isInteracting = !isInteracting;
            rigidBody.useGravity = !isInteracting;
            rigidBody.constraints = isInteracting ? RigidbodyConstraints.FreezePosition : RigidbodyConstraints.None;
            Physics.IgnoreLayerCollision(6, 3, isInteracting);

            if (isInteracting)
            {
                var inpectorHolder = GameObject.FindWithTag("ObjectInspectorHolder");
                if (inpectorHolder != null)
                {
                    initialPosition = this.transform.position;
                    this.transform.position = inpectorHolder.transform.position;
                }
            }
            else
            {
                this.transform.position = initialPosition;
            }
        }
    }
}