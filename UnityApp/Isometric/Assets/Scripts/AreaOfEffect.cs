﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaOfEffect : MonoBehaviour {

    public float PushForce = 10;
    public float PushArea = 10;
    public Weapon Owner;

    List<Collider> hits = new List<Collider>();

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().AddExplosionForce(PushForce, transform.position, PushArea);
        }

        if(other.tag == "Enemy")
        { 
            Owner.OnHit(other);
            hits.Add(other);
        }
    }
}
