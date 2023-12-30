using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(new Vector3(0, 180, 0));

    }
}
