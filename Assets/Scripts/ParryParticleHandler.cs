using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryParticleHandler : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;


    public void fire()
    {
        particle1.Play();
        particle2.Play();
    }
}
