using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        public static Action<Vector3> OnDirectionMovementPerformed;
        public static Action<Vector2> OnLookMovementPerformed;

        private PlayerControls playerControls;


        #region Unity Methods

        void Awake()
        {
            playerControls = new PlayerControls();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            playerControls.Player.Movement.performed += OnMovePerformed;
            playerControls.Player.Look.performed += OnLookPerformed;

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
            OnLookMovementPerformed?.Invoke(playerControls.Player.Look.ReadValue<Vector2>());
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            OnDirectionMovementPerformed?.Invoke(playerControls.Player.Movement.ReadValue<Vector2>());
        }

        //public Vector2 GetMovementPerformed()
        //{
        //    return playerControls.Player.Movement.ReadValue<Vector2>();
        //}

        //public Vector2 GetLookPerformed()
        //{
        //    return playerControls.Player.Look.ReadValue<Vector2>();
        //}
    }

}

