using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AreaOfEffect : MonoBehaviour
{
    //public float PushForce = 10;
    //public float PushArea = 10;
    public Weapon Owner;
    public UnityEvent Hit;
    public float forwardForce;

    List<Collider> hits = new List<Collider>();

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce + transform.up * forwardForce/3, ForceMode.Impulse);
        Physics.IgnoreCollision(GetComponent<Collider>(), Owner.transform.root.GetComponent<Collider>());
    }

    public void OnCollisionEnter(Collision collision)
    {
        // hit & explode
        Owner.OnHit(collision);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        Hit.Invoke();
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        /*if(other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().AddExplosionForce(PushForce, transform.position, PushArea);
        }*/

        //if(other.tag == "Enemy")
        {
            //var coll = Physics.OverlapSphere(transform.position, Owner.AreaForceSize);
            //RaycastHit hit;
            //if( Physics.SphereCast(new Ray(transform.position, transform.forward), Owner.AreaForceSize, out hit, 0))
            //foreach (var c in hit.)
            //    Owner.OnHit(c);
            //Owner.OnHit(other);
            //hits.Add(other);
        }


    }
}
