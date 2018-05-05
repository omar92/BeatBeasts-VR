﻿using UnityEngine;

public class Gun : MonoBehaviour, IControllable {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    float nextTimeToFire = 0f;
    public Rigidbody projectile;

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
        if(this.gameObject.activeInHierarchy == true)
        {
            RaycastHit hit;
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, projectile.transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 200);
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward, Color.green, range, true);
                TargetMonester target = hit.transform.GetComponent<TargetMonester>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}