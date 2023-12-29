using Scrips.PlayerInput;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField] private float maxVelocity = 0;
    [SerializeField] private float speedRate = 0;

    #endregion

    CharacterController characterController = null;
    Vector3 _previousInputDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InputManager.OnDirectionMovementPerformed += PerformMovement;
    }

    private void PerformMovement(Vector3 movementDirection)
    {
        if (_previousInputDirection == movementDirection)
            return;

        _previousInputDirection = movementDirection * speedRate;
    }

    protected virtual void FixedUpdate()
    {
        characterController.Move(Convert.ToInt32(characterController.velocity.magnitude <= maxVelocity) * _previousInputDirection.normalized);
    }
}
