using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerManager : MonoBehaviour
{
    AudioSource source;

    [Header("Laugh")]
    public AudioClip voLaugh1;
    public AudioClip voLaugh2;
    public AudioClip voLaugh3;

    [Header("Ball Shouts")]
    public AudioClip curveball_long;
    public AudioClip curveball_short;
    public AudioClip fastball_long;
    public AudioClip fastball_short;
    public AudioClip screwball_long;
    public AudioClip screwball_short;

    [Header("Annoucer Things")]
    public AudioClip hurt1;
    public AudioClip hurt2;
    public AudioClip hurt3;
    public AudioClip matchSet;
    public AudioClip myPretties;
    public AudioClip winner;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playVOLaugh1()
    {
        source.clip = voLaugh1;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOLaugh2()
    {
        source.clip = voLaugh2;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOLaugh3()
    {
        source.clip = voLaugh3;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOcurveLong()
    {
        source.clip = curveball_long;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOcurveShort()
    {
        source.clip = curveball_short;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOfastShort()
    {
        source.clip = fastball_short;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOfastLong()
    {
        source.clip = fastball_long;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOscrewShort()
    {
        source.clip = screwball_short;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOscrewLong()
    {
        source.clip = screwball_long;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOmatchSet()
    {
        source.clip = matchSet;
        source.pitch = 1f;
        source.Play();
    }
    public void playVOwinner()
    {
        source.clip = winner;
        source.pitch = 1f;
        source.Play();
    }
    
    public void playVOhurt3()
    {
        source.clip = hurt3;
        source.pitch = 1f;
        source.Play();
    }
      public void playVOpretties()
    {
        source.clip = myPretties;
        source.pitch = 1f;
        source.Play();
    }

    public void LaughPicker()
    {
        float laughPicker = Random.Range(0f, 1f);

        if (laughPicker < .33f)
        {
           playVOLaugh1();
        }
        if (laughPicker > .33f && laughPicker < .66f)
        {
           playVOLaugh2();
        }
        if (laughPicker > .66f)
        {
           playVOLaugh3();
        }
    }

    public void CurvePicker()
    {
        float curvePicker = Random.Range(0f, 1f);

        if (curvePicker < .5f)
        {
            playVOcurveShort();
        }
        else playVOcurveLong();
    }
    public void FastPicker()
    {
        float fastPicker = Random.Range(0f, 1f);

        if (fastPicker < .5f)
        {
            playVOfastShort();
        }
        else playVOfastLong();
    }
    public void ScrewPicker()
    {
        float screwPicker = Random.Range(0f, 1f);

        if (screwPicker < .5f)
        {
            playVOscrewShort();
        }
        else playVOscrewLong();
    }
}
