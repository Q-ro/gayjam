using Scripts.Interaction;
using Scripts.PlayerInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObjectController : MonoBehaviour
{
    [SerializeField] float pickupRange = 20f;
    //private Camera camera;
    //private Transform inspectedObjectTransform;
    



    private void Start()
    {
        //camera = Camera.main;
        InputManager.Interact += OnInteractPerformed;
    }

    private void OnInteractPerformed()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
        {
            DoInteraction(hit.transform.gameObject);
        }
    }

    private void DoInteraction(GameObject interactableObject)
    {
        InteractableObjectBase interactable;
        if (interactableObject.TryGetComponent<InteractableObjectBase>(out interactable))
        {
            interactable.Interact();
        }
    }

    //private void Update()
    //{

    //}
}
