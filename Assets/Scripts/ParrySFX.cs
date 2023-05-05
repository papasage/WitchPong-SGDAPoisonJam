using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrySFX : MonoBehaviour
{
    AudioSource source;
    public AudioClip sfxParry;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSFXParry()
    {
        source.clip = sfxParry;
        source.pitch = 1;
        source.Play();
    }

}
