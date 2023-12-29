using UnityEngine;

namespace Scripts.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class InteractableObjectBase : MonoBehaviour
    {
        protected Rigidbody rigidBody;
        protected float rotationSpeed = 5f;
        private bool isInteractable = false;

        public Rigidbody RigidBody { get => rigidBody; }
        public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

        protected virtual void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public abstract void Interact();
    }
}