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
        InteractableObjectBase obj;
        if (TryGetComponent<InteractableObjectBase>(out obj))
        {
            obj.IsInteractable = true;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObjectBase obj;
        if (TryGetComponent<InteractableObjectBase>(out obj))
        {
            obj.IsInteractable = false;
            Debug.Log("exit");
        }
    }
}
