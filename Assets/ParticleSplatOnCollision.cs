﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSplatOnCollision : MonoBehaviour {

    public ParticleSystem particleLauncher;
    public Gradient particleColorGradient;
    public ParticleDecalPool dropletDecalPool;

    List<ParticleCollisionEvent> collisionEvents;


    void Start() {
        collisionEvents = new List<ParticleCollisionEvent>();
        if (dropletDecalPool == null) {
            dropletDecalPool = GameObject.Find("ParticleSplatterController").GetComponent<ParticleDecalPool>();
        }
    }

    void OnParticleCollision(GameObject other) {
        int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        int i = 0;
        while (i < numCollisionEvents) {
            dropletDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            i++;
        }

    }

}
