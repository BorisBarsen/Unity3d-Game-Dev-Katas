using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    [SerializeField] private Camera fpcCamera;
    [SerializeField] private GameObject fpcObject;

    [SerializeField] float mouseSensetive = 1;

    [SerializeField] float damage = 1f;

    float xRotInput;
    float yRotInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseMove();

        Vector3 forward = fpcCamera.transform.TransformDirection(Vector3.forward) * 20;
        Debug.DrawRay(fpcCamera.transform.position, forward, Color.green);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(fpcCamera.transform.position, fpcCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Shoot(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("Hit nothing");
        }
    }

    private void Shoot(GameObject target)
    {
       if (target.GetComponent<TargetHealth>())
        {
            Debug.Log("Hit" + target.name);

            target.GetComponent<TargetHealth>().TakeDamage(damage);
        }
    }

    private void MouseMove()
    {
        xRotInput += Input.GetAxis("Mouse Y") * mouseSensetive * -1;
        yRotInput += Input.GetAxis("Mouse X") * mouseSensetive;

        xRotInput = Mathf.Clamp(xRotInput, -90, 90);

        fpcCamera.transform.rotation = Quaternion.Euler(xRotInput, yRotInput, 0f);
        fpcObject.transform.rotation = Quaternion.Euler(0f, yRotInput, 0f);
    }
}
