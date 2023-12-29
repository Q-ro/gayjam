using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private void Update()
    {
        //Update Mouse position to player position
        transform.position = Player.transform.position;
    }

}