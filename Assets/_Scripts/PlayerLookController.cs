using Scripts.PlayerInput;
using UnityEngine;

namespace Scripts.PlayerMovement
{
    public class PlayerLookController : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [SerializeField] private float mouse_sensitivity = 10f;
        float xRotation;
        float yRotation;

        void Start()
        {
            InputManager.OnLookMovementPerformed += OnLookMovementPerformed;
        }

        private void OnLookMovementPerformed(Vector2 mousemovement)
        {
            xRotation -= mousemovement.y * Time.deltaTime * mouse_sensitivity;
            //Clamp rotion vectors
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            yRotation += mousemovement.x * Time.deltaTime * mouse_sensitivity;
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            //Rotating the player
            Player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}