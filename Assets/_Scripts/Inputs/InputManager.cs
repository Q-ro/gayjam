using Scripts.PlayerMovement;
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
        public static Action OnInteract;
        public static Action SubmitDialogue;
        public static Action<bool> OnPlayerMouseHeldPerformed;

        private PlayerControls playerControls;


        #region Unity Methods

        void Awake()
        {
            playerControls = new PlayerControls();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerControls.Player.Movement.performed += OnMovePerformed;
            playerControls.Player.Look.performed += OnLookPerformed;
            playerControls.Player.PickUp.performed += OnPickupPerformed;
            playerControls.Player.Interact.performed += OnInteractPerformed;
            playerControls.Player.SubmitDialogue.performed += OnSubmitDialoguePerformed;
            playerControls.Player.ReleaseCharInteraction.performed += OnReleaseChaeInteractionPerformed;
            playerControls.Player.MousePressed.performed += (context) => OnPlayerMouseHeldPerformed.Invoke(true);
            playerControls.Player.MousePressed.canceled += (context) => OnPlayerMouseHeldPerformed.Invoke(false);
        }

        private void OnMousePressed(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        private void OnDestroy()
        {
            playerControls.Player.Movement.performed -= OnMovePerformed;
            playerControls.Player.Look.performed -= OnLookPerformed;
            playerControls.Player.PickUp.performed -= OnPickupPerformed;
            playerControls.Player.Interact.performed -= OnInteractPerformed;
            playerControls.Player.SubmitDialogue.performed -= OnSubmitDialoguePerformed;
            playerControls.Player.MousePressed.performed -= (context) => OnPlayerMouseHeldPerformed.Invoke(true);
            playerControls.Player.MousePressed.canceled -= (context) => OnPlayerMouseHeldPerformed.Invoke(false);
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
        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            OnInteract?.Invoke();
        }
        private void OnSubmitDialoguePerformed(InputAction.CallbackContext context)
        {
            SubmitDialogue?.Invoke();
        }

        private void OnReleaseChaeInteractionPerformed(InputAction.CallbackContext context)
        {
            PlayerMovementController.OnLockPlayerMovementPerformed?.Invoke(false);
        }

    }
}

