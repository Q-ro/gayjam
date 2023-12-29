using System;
using UnityEngine;

namespace Scripts.Interaction
{
    public enum InteractionTypes
    {
        None,
        Inspect,
        Read,
    }

    [RequireComponent(typeof(Rigidbody))]
    public abstract class InteractableObjectBase : MonoBehaviour
    {
        protected InteractionTypes interactionType;
        private Rigidbody rigidBody;

        public Rigidbody RigidBody { get => rigidBody; }

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public abstract void Interact();
    }
}