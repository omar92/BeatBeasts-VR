﻿using System;
using UnityEngine;

public class Gun : MonoBehaviour, IControllable {


    public float range = 100f;
    public float fireRate = 15f;
    public float destroyAfter = 0.1f;

    public GameEvent GunVibrate;
    public GameEvent BossHitE;
    float nextTimeToFire = 0f; 
    public Rigidbody projectile;
    public GeneralSounds sounds;
    AudioSource Source;
    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }
    public void OnTrigger(bool isDown)
    {
        if (isDown)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {

        Source.clip = sounds.RangedShoot;
        Source.Play();
        GunVibrate.Raise();
        if (this.gameObject.activeInHierarchy == true)
        {
            RaycastHit hit;
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, projectile.transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 200);
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward, Color.green, range, true);
                var target = hit.transform.GetComponent<TargetMonester>();
                if (target)
                {
                    target.OnHit();
                    BossHitE.Raise();
                }
            }
            Destroy(clone.gameObject, destroyAfter);
        }
    }

    public void OnSqueez(bool isDown)
    {
        //throw new NotImplementedException();
    }
}
