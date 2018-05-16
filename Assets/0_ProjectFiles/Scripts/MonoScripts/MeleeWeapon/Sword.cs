﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using VRTK;

public class Sword : MonoBehaviour
{
    public FloatVariable speed;
    public Direction dir;

    Coroutine collidedSwordsVibration;

    public float swordssVibrationStrength = .9f;
    public float swordssVibrationInterval = 0.01f;

    public GameEvent swordCut;
    // Use this for initialization
    public Vector3Variable currentPos;
    Vector3 previuosPos;
    AudioSource audioSource;

    public ArrayList xyPositions;
   
    void Start()
    {
        previuosPos = Vector3.zero;
        audioSource = GetComponent<AudioSource>();
        xyPositions = new ArrayList ();
        xyPositions.Add(new Vector2(transform.position.x, transform.position.y));
    }

    void Update()
    {
        currentPos.value = transform.position;
        speed.value = (currentPos.value - previuosPos).magnitude / Time.deltaTime;
        CalculateDierection();
        previuosPos = currentPos.value;

        if (xyPositions.Count<10)
        {
            xyPositions.Add(new Vector2(transform.position.x, transform.position.y));
        }
        else
        {    
                xyPositions.Clear();
        }
        
    }

    void CalculateDierection()
    {
        var direction = (previuosPos - currentPos.value).normalized;
        var angle = Vector2.Dot(direction, Vector3.up) / direction.magnitude;
         dir = Direction.NONE;
        Color color = Color.red;
      //  Debug.Log("angle " + angle);
        if (angle > -.5 && angle < .5)
        {
            if (direction.x > 0)
            {
                  color = Color.red;
                dir = Direction.LEFT;
            }
            else
            {
                  color = Color.green;
                dir = Direction.RIGHT;
            }
        }
        if (angle <= -.5)
        {
             color = Color.blue;
            dir = Direction.UP;
        }
        if (angle >= .5)
        {
             color = Color.yellow;
            dir = Direction.DOWN;
        }
        //   Debug.Log(Dir+": " + angle + " : " + direction);
          Debug.DrawLine(previuosPos , currentPos.value, color, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            if(collidedSwordsVibration == null)
                collidedSwordsVibration = StartCoroutine(CollidedSwordsVibrationFun());
        }

        if (other.gameObject.tag == "Note")
        {
            swordCut.Raise();
            NoteScript sc = other.GetComponent<NoteScript>();
            audioSource.Play();
        }
    }

    private IEnumerator CollidedSwordsVibrationFun()
    {
        while (true)
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(transform.parent.gameObject), swordssVibrationStrength);
            yield return new WaitForSeconds(swordssVibrationInterval);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidedSwordsVibration != null)
        {
            StopCoroutine(collidedSwordsVibration);
            collidedSwordsVibration = null;
        }
    }
}
