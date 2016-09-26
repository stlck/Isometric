﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public RangedWeapon Owner;
    public Transform HitEffect;
    public float ForwardForce = 50;
    public Transform hitEffect { get; set; }

	// Use this for initialization
	void Start () {
        if (HitEffect != null)
        {
            hitEffect = Instantiate(HitEffect);
            hitEffect.gameObject.SetActive(false);
        }
	}

    public virtual void ShootMe()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(transform.forward * ForwardForce);
    }

    void OnEnable()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " " + collision.collider.name);
        if (hitEffect != null)
        {
            hitEffect.position = collision.contacts[0].point;
            hitEffect.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
        Owner.OnHit(collision);
    }
}
