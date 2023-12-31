using System;
using UnityEngine;

public class BackgroundNoiseAudioController : MonoBehaviour
{
    public static Action OnSetSilenceBackgroundNoise;

    [SerializeField] private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        OnSetSilenceBackgroundNoise += SilenceBackgroundNoise;
    }

    private void SilenceBackgroundNoise()
    {
        m_AudioSource.Stop();
    }
}
