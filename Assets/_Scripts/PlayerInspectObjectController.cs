using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInspectObjectController : MonoBehaviour
{

    private Camera _camera;
    private Transform _InspectedObjectTransform;
    public float deltaRotationX;
    public float deltaRotationY;

    public float rotationSpeed = 2;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {

    }
}
