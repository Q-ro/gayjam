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
        public static Action Interact;
        public static Action SubmitDialogue;
        public static Action DialogueOption1;
        public static Action DialogueOption2;
        public static Action DialogueOption3;

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
            playerControls.Player.Dialogue1.performed += OnDialogueOption1Performed;
            playerControls.Player.Dialogue2.performed += OnDialogueOption2Performed;
            playerControls.Player.Dialogue3.performed += OnDialogueOption3Performed;
        }

        private void OnDestroy()
        {
            playerControls.Player.Movement.performed -= OnMovePerformed;
            playerControls.Player.Look.performed -= OnLookPerformed;
            playerControls.Player.PickUp.performed -= OnPickupPerformed;
            playerControls.Player.Interact.performed -= OnInteractPerformed;
            playerControls.Player.SubmitDialogue.performed -= OnSubmitDialoguePerformed;
            playerControls.Player.Dialogue1.performed -= OnDialogueOption1Performed;
            playerControls.Player.Dialogue2.performed -= OnDialogueOption2Performed;
            playerControls.Player.Dialogue3.performed -= OnDialogueOption3Performed;
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
            Interact?.Invoke();
        }
        private void OnSubmitDialoguePerformed(InputAction.CallbackContext context)
        {
            SubmitDialogue?.Invoke();
        }
        private void OnDialogueOption1Performed(InputAction.CallbackContext context)
        {
            DialogueOption1?.Invoke();
        }
        private void OnDialogueOption2Performed(InputAction.CallbackContext context)
        {
            DialogueOption2?.Invoke();
        }
        private void OnDialogueOption3Performed(InputAction.CallbackContext context)
        {
            DialogueOption3?.Invoke();
        }
    }
}

