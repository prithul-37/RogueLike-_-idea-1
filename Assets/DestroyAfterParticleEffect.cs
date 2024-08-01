using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterParticleEffect : MonoBehaviour
{
    public ParticleSystem _particleSystem;

    // Update is called once per frame
    void Update()
    {
        if(_particleSystem.particleCount == 0) Destroy(gameObject);
    }
}
