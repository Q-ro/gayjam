using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private bool playerInRange;
    private void Awake(){
        playerInRange = false;
    }

    private void Update(){
        if(playerInRange){
        } else {
        }
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            playerInRange = false;
        }
        
    }
}
