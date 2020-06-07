using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        light.enabled = !light.enabled;

    }
}
