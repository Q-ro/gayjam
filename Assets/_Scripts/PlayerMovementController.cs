using Scripts.PlayerInput;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.PlayerMovement
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        public static Action<bool> OnLockPlayerMovementPerformed;
        public static Action<Vector3, float, Action> MovementPlayerToPosition;

        #region Inspector Variables

        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] InputManager inputManager = null;

        #endregion

        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;

        private Vector3 horizontalInput;
        bool isInteracting = false;
        bool isMovementLocked = false;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            InputManager.OnDirectionMovement += PerformMovement;
            PlayerInteractObjectController.OnInteractionStarted += OnInteractionStarted;
            OnLockPlayerMovementPerformed += OnMovementLocked;
            MovementPlayerToPosition += OnMovePlayerToPosition;
        }

        private void OnMovePlayerToPosition(Vector3 vector, float speed, Action callback)
        {
            StopAllCoroutines();
            StartCoroutine(COMoveToTarget(vector, speed, callback));
        }

        IEnumerator COMoveToTarget(Vector3 targetPosition, float speed, Action callback)
        {
            while (Vector3.Distance(transform.position, targetPosition) > 0.2f)  // Adjust tolerance as needed
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            callback?.Invoke();
        }


        private void OnMovementLocked(bool obj)
        {
            isMovementLocked = obj;
            if (!isMovementLocked)
                isInteracting = false;
        }

        private void OnInteractionStarted()
        {
            isInteracting = !isInteracting;
        }

        private void PerformMovement(Vector3 vector)
        {
            if (horizontalInput == vector)
                return;

            horizontalInput = vector;
        }

        private void Update()
        {
            if (isInteracting || isMovementLocked)
                return;
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            MoveHorizontal();
            MoveVertical();
        }

        private void MoveVertical()
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        private Vector3 MoveHorizontal()
        {
            Vector3 move = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * playerSpeed;
            controller.Move(move * Time.deltaTime);
            return move;
        }
    }
}

