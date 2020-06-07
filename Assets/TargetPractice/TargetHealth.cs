using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    [SerializeField] float health;

    [SerializeField] AudioClip deathSFX;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            DeathEvent();
        }
    }

    private void DeathEvent()
    {

        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = transform.position;
        AudioSource aSource = tempGO.AddComponent<AudioSource>();
        aSource.clip = deathSFX; 
        aSource.Play(); 
        Destroy(tempGO, deathSFX.length);

        Destroy(gameObject);
    }
}
