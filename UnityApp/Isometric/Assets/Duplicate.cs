using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour
{
    public int x = 3;
    public int y = 6;
    public int z = 2;
    public bool spawn = false;
    public float minForce;

    // Use this for initialization
    void Start()
    {
        if (spawn)
        {
            spawn = false;
            var scale = transform.localScale;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int k = 0; k < z; k++)
                    {
                        if (i > 0 || j > 0 || k > 0)
                            Instantiate(transform, transform.position + transform.up * j * scale.y + transform.right * i * scale.x + transform.forward * k * scale.z, transform.rotation, transform.parent);
                    }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NoOnMouseDown()
    {
        var c = Physics.OverlapSphere(transform.position, 4);
        foreach (var coll in c)
            if (coll.GetComponent<Rigidbody>() != null)
            {
                coll.GetComponent<Rigidbody>().isKinematic = false;
                coll.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 4);
            }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minForce)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
