using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    private AudioSource audioSource;

    void Awake()
    {
        _instance = this;
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void setMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
