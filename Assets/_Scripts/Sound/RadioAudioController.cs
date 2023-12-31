using System;
using UnityEngine;

public class RadioAudioController : MonoBehaviour
{
    public static Action OnSetRadioStatic;

    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip silence;

    // Start is called before the first frame update
    void Start()
    {
        OnSetRadioStatic += SwitchToRadioStatic;
    }

    private void SwitchToRadioStatic()
    {
        m_AudioSource.Stop();
        m_AudioSource.clip = silence;
        //m_AudioSource.volume = 0.75f;
        m_AudioSource.Play();
    }
}
