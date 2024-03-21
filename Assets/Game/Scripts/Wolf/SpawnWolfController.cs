using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWolfController : MonoBehaviour
{
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    ParticleSystem particle;

    public void SpawnWolf()
    {
        particle.Play();
        Instantiate(wolf, transform.position, Quaternion.identity);
    }
}
