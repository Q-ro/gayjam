using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scrips.PlayerInput
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
            playerControls.Player.Movement.performed += MovementPerformed;
            playerControls.Player.Look.performed += LookPerformed;
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

        private void MovementPerformed(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            var direction = new Vector3(input.x, 0, input.y);
            OnDirectionMovementPerformed?.Invoke(direction);
        }

        private void LookPerformed(InputAction.CallbackContext context)
        {
            OnLookMovementPerformed?.Invoke(context.ReadValue<Vector2>());
        }
    }

}

