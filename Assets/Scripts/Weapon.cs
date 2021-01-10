﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 20;
    [SerializeField] private float force = 155;
    [SerializeField] private float range = 200;
    [SerializeField] private AudioClip shotSFX;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _audioSource.PlayOneShot(shotSFX);

        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position,_cam.transform.forward, out hit, range))
        {
            Debug.Log("Попадание");
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
