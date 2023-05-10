using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource source;
    public AudioClip Track1;
    public AudioClip Track2;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomTrackPicker()
    {
        int _randomPicker = Random.RandomRange(1, 2);

        if (_randomPicker == 1)
        {
            playSFXTrack1();
        }
        else playSFXTrack2();
    }

    public void playSFXTrack1()
    {
        source.clip = Track1;
        source.Play();
    } 
    
    public void playSFXTrack2()
    {
        source.clip = Track2;
        source.Play();
    }
}
