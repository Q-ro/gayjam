using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        public static Action<Vector3> OnDirectionMovement;
        public static Action<Vector2> OnLookMovement;
        public static Action OnPickup;

        private PlayerControls playerControls;


        #region Unity Methods

        void Awake()
        {
            playerControls = new PlayerControls();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            playerControls.Player.Movement.performed += OnMovePerformed;
            playerControls.Player.Look.performed += OnLookPerformed;
            playerControls.Player.PickUp.performed += OnPickupPerformed;

        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        #endregion

        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            OnLookMovement?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            OnDirectionMovement?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnPickupPerformed(InputAction.CallbackContext context)
        {
            OnPickup?.Invoke();
        }
    }
}

