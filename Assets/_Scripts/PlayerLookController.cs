using Scrips.PlayerInput;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float mouse_sensitivity = 10f;
    float xrotation;
    float yrotation;

    void Start()
    {
        InputManager.OnLookMovementPerformed += OnLookMovementPerformed;
    }

    private void OnLookMovementPerformed(Vector2 mousemovement)
    {
        xrotation -= mousemovement.y * Time.deltaTime * mouse_sensitivity;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        yrotation += mousemovement.x * Time.deltaTime * mouse_sensitivity;
        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        //Rotating the player
        Player.transform.localRotation = Quaternion.Euler(0, yrotation, 0);
    }
}
