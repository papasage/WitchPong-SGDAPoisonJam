using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem particleLeft;
    [SerializeField] ParticleSystem particleRight;
    [SerializeField] ParticleSystem particleBall;

   public void particleLeftScore(Transform location)
    {
        Instantiate(particleLeft, location);
    }
}
