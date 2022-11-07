using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartParticles : MonoBehaviour
{
    ParticleSystem particleSystemA;
    void Start()
    {
        particleSystemA = GetComponent<ParticleSystem>();
        particleSystemA.Play();
    }



}
