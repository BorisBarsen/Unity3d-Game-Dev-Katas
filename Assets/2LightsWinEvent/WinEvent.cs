using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEvent : MonoBehaviour
{
    [SerializeField] GameObject lights;
    [SerializeField] ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AllLightAreOn())
        {
            particleSystem.Play();
        }
    }

    private bool AllLightAreOn()
    {
        foreach (Light light in lights.GetComponentsInChildren<Light>())
        {
            if (!light.enabled) return false;
        }

        return true;
    }
}
