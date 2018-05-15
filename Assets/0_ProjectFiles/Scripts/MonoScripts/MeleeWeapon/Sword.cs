﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using VRTK;

public class Sword : MonoBehaviour
{
    public FloatVariable speed;
    
    public GameEvent ballCut;
    public GameEvent swordCut;
    // Use this for initialization
    public Vector3Variable currentPos;
    Vector3 previuosPos;
    AudioSource audioSource;

    public List<Vector2> xyPositions;

    void Start()
    {
        previuosPos = Vector3.zero;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentPos.value = transform.position;
        speed.value = (currentPos.value - previuosPos).magnitude / Time.deltaTime;
        previuosPos = currentPos.value;
        // VRTK_ControllerHaptics.TriggerHapticPulse
        //(VRTK_ControllerReference.GetControllerReference(transform.parent.gameObject), speed.value);

        if (xyPositions.Capacity<10)
        {
            xyPositions.Add(new Vector2(transform.position.x, transform.position.y));
        }
        else
        {
            for (int i=0; i<xyPositions.Capacity;i++)
            {
                xyPositions.Clear();
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Minion")
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            ballCut.Raise();
            swordCut.Raise();
            NoteScript sc = other.GetComponent<NoteScript>();
            audioSource.Play();
        }
    }
}
