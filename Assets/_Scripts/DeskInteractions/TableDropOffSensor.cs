using Scripts.Interaction;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class TableDropOffSensor : MonoBehaviour
{
    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        InteractableObjectBase obj;
        if (other.TryGetComponent<InteractableObjectBase>(out obj))
        {
            obj.IsInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        InteractableObjectBase obj;
        if (other.TryGetComponent<InteractableObjectBase>(out obj))
        {
            obj.IsInteractable = false;
        }
    }
}
