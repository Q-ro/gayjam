using Scripts.PlayerInput;
using UnityEngine;

namespace Scripts.PlayerMovement
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
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

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            InputManager.OnDirectionMovement += PerformMovement;
            PlayerInteractObjectController.OnInteractionStarted += OnInteractionStarted;
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
            if (isInteracting)
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

