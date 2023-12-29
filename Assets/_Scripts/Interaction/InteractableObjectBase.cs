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
        protected Rigidbody rigidBody;
        protected float rotationSpeed = 20f;

        public Rigidbody RigidBody { get => rigidBody; }

        protected virtual void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public abstract void Interact();
    }
}