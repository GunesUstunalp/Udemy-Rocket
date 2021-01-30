using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrustSound;

    [SerializeField]  float mainThrust = 1000f;
    [SerializeField] float rcsThrust = 100f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        thrustSound.volume = 1f;    //to solve popping sounds when thrust is stopped
        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

            if (!thrustSound.isPlaying)
                thrustSound.Play();
        }
        else
        {
            thrustSound.volume = 0f;   //to solve popping sounds when thrust is stopped
            //thrustSound.Stop();
        }
            
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * rotationThisFrame);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false; //resume normal control of rotation
    }
}
