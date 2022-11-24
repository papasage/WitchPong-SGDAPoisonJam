using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource source;

    public AudioClip sfxPaddleHit;
    public AudioClip sfxScore;
    public AudioClip sfxCycleUp;
    public AudioClip sfxCycleDown;
    public AudioClip sfxCycleDefault;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSFXPaddleHit()
    {
        source.clip = sfxPaddleHit;
        source.pitch = 1f;
        source.Play();
    }
    
    public void playSFXWallHit()
    {
        source.clip = sfxPaddleHit;
        source.pitch = 1.5f;
        source.Play();
    }
    
    public void playSFXScore()
    {
        source.clip = sfxScore;
        source.pitch = 1;
        source.Play();
    }
    
    public void playSFXCycleUp()
    {
        source.clip = sfxCycleUp;
        source.pitch = 1;
        source.Play();
    }
    
    public void playSFXCycleDown()
    {
        source.clip = sfxCycleDown;
        source.pitch = 1;
        source.Play();
    } 
    public void playSFXCycleDefault()
    {
        source.clip = sfxCycleDefault;
        source.pitch = 1;
        source.Play();
    }

}
