using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour
{
    public float x = 3;
    public float y = 6;
    public float z = 2;
    public bool spawn = false;
    public float minForce;

    bool hit = false;
    float timer = 0f;
    Material mat;
    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        mat = GetComponent<MeshRenderer>().material;

        if (spawn)
        {
            spawn = false;
            var scale = transform.localScale;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int k = 0; k < z; k++)
                    {
                        if (i > 0 || j > 0 || k > 0)
                        {
                            /*var go =(Transform)*/
                            Instantiate(transform, transform.position + transform.up * j * scale.y + transform.right * i * scale.x + transform.forward * k * scale.z, transform.rotation, transform.parent);
                            //go.SetParent(transform);
                        }
                    }

            var nav = gameObject.AddComponent<NavMeshObstacle>();
            nav.center = Vector3.right * ((x / 2) - .5f) + Vector3.up * ((y / 2) - .5f) + Vector3.forward * ((z/2)-.5f);
            nav.size = new Vector3(x, y, z);

        }
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minForce)
        {
            hit = true;
        }
    }

    void Update()
    {
        if(hit)
        {
            timer += Time.deltaTime;
            if(timer >= 3f)
            {
                mat.SetFloat("_SliceAmount", timer - 3f);
                if (timer >= 4f)
                {
                    Destroy(gameObject);
                }
            }
        }
        else if(rigidBody.velocity.magnitude >= minForce)
        {
            timer = Random.Range(-2f, 2f);
            hit = true;
        }
    }
}
