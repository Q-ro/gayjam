using UnityEngine;

namespace Scripts.Interaction
{
    public enum InteractionTypes
    {
        Inspect,
        Read,
    }

    [RequireComponent(typeof(Rigidbody))]
    public abstract class InteractableObjectBase : MonoBehaviour
    {
        [SerializeField] InteractionTypes interactionTypes;
        private Rigidbody rigidBody;

        public Rigidbody RigidBody { get => rigidBody; }

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public abstract void Interact();
    }
}