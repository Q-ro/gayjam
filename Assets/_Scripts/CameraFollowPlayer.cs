using UnityEngine;

namespace Scripts.PlayerMovement
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [SerializeField] GameObject Player;

        private void Update()
        {
            //Update Mouse position to player position
            transform.position = Player.transform.position;
        }

    }
}