using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LigthingManager : MonoBehaviour
{
    public static Action OnStartLightSequenceanimation;

    [SerializeField] private Light[] lights;
    [SerializeField] private float timeBetweenLights;

    void Start()
    {
        OnStartLightSequenceanimation += StartAnimation;
    }

    private void StartAnimation()
    {
        StartCoroutine(COLightsAnimation());
    }

    IEnumerator COLightsAnimation()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0;
            yield return new WaitForSeconds(timeBetweenLights);
        }

        SceneManager.LoadScene(1);
    }
}
