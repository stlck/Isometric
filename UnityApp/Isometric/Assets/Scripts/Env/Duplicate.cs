using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour
{
    //public float x = 3;
    //public float y = 6;
    //public float z = 2;
    //public bool spawn = false;
    public float minForce;

    public float Health = 300;

    bool hit = false;
    float timer = 0f;
    Material mat;
    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        mat = GetComponent<MeshRenderer>().material;
        mat.SetTextureOffset("_MainTex", new Vector2(((float)Random.Range(1,5))/4f, ((float)Random.Range(1, 5)) / 4f));
        
        //if (spawn)
        //{
        //    spawn = false;
            
        //}
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Rel : " + collision.relativeVelocity + ". " + collision.relativeVelocity.magnitude);

        if (!hit && collision.relativeVelocity.magnitude > minForce)
        {
            //hit = true;
            Health -= collision.relativeVelocity.magnitude;
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
        else if(Health<= 0)//(rigidBody.velocity.magnitude >= minForce)
        {
            timer = Random.Range(-2f, 2f);
            hit = true;
        }
    }
}
