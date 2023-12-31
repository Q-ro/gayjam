using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiplomaController : MonoBehaviour
{
    public static Action OnReturnBook;
    // Start is called before the first frame update
    void Start()
    {
        OnReturnBook += DestroyObject;
    }

    void OnDestroy(){
        OnReturnBook -= DestroyObject;
    }

    private void DestroyObject(){
        Debug.Log("Destroying this gameobject");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
