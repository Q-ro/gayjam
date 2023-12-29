using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractableObjectBase : MonoBehaviour
{
    private Rigidbody rb;

    public Rigidbody RigidBody { get => rb; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void Interact();
}
