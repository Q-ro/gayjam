using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPhotoController : MonoBehaviour
{
    public static Action OnReturnPolaroid;
    // Start is called before the first frame update
    void Start()
    {
        OnReturnPolaroid += DestroyObject;
    }

    void OnDestroy(){
        OnReturnPolaroid -= DestroyObject;
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
