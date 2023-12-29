using Scrips.PlayerInput;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scrips.PlayerMovement
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

        private Vector3 _previousInputDirection;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            InputManager.OnDirectionMovementPerformed += PerformMovement;
        }

        private void PerformMovement(Vector3 vector)
        {
            if (_previousInputDirection == vector)
                return;

            _previousInputDirection = vector;


        }

        private void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = MoveHorizontal();

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            MoveVertical();
        }

        private void MoveVertical()
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        private Vector3 MoveHorizontal()
        {

            Vector3 move = (transform.right * _previousInputDirection.x + transform.forward * _previousInputDirection.y) * playerSpeed;

            //move = input_control.Player_Map.Movement.ReadValue<Vector2>();
            //float forcez = _previousInputDirection.x * playerSpeed * Time.deltaTime;
            //float forcex = _previousInputDirection.y * playerSpeed * Time.deltaTime;
            ////rb.AddForce(transform.forward * forcex, ForceMode.Force);
            ////rb.AddForce(transform.right * forcez, ForceMode.Force);

            //Vector3 move = transform.forward * forcex + transform.right * forcez;
            //controller.Move(move.normalized * Time.deltaTime * playerSpeed);

            //Vector2 movement = _previousInputDirection;
            //Vector3 move = new Vector3(movement.x, 0, movement.y);

            ////float forcez =  move.x * movement_force * Time.deltaTime;
            ////float forcex = move.y * movement_force * Time.deltaTime;

            controller.Move(move * Time.deltaTime);
            return move;
        }
    }
}

