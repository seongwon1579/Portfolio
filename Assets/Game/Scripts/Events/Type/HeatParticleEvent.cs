using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatParticleEvent : Events
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public override void DoEvent()
    {
        particle.Play();
    }
}
