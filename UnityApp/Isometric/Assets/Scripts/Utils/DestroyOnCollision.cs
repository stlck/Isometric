using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

    public ParticleSystem Effect;

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);

        Effect.transform.position = coll.contacts[0].point;
        Effect.Play();
    }
}
