using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Laser : MonoBehaviour {

    public LaserWeapon Owner;
    //public LayerMask IgnoreField;
    public LineRenderer Line;
    public float disableTime = .1f;
    public float RAnge = 40;
    public GameObject HitEffect;
    float currentTime;

    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit rch;
        if (Physics.Raycast(ray, out rch, RAnge))
        {
            Line.SetPosition(1, Vector3.forward * rch.distance);
            Owner.OnHit(rch.collider);
            HitEffect.transform.position = rch.point - transform.forward * .1f;
            HitEffect.SetActive(true);
        }
        else
        {
            HitEffect.SetActive(false);
            Line.SetPosition(1, Vector3.forward * RAnge);
        }

        if (gameObject.active)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= disableTime)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ShootMe()
    {
        gameObject.SetActive(true);
        currentTime = 0f;
    }
}
