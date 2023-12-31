using System;
using UnityEngine;

public class BackgroundNoiseAudioController : MonoBehaviour
{
    public static Action OnSetSilenceBackgroundNoise;

    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_AudioClip;

    // Start is called before the first frame update
    void Start()
    {
        OnSetSilenceBackgroundNoise += SilenceBackgroundNoise;
    }

    private void SilenceBackgroundNoise()
    {
        m_AudioSource.Stop();
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.Play();
    }
}
