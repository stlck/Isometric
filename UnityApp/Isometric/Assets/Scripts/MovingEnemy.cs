using UnityEngine;
using System.Collections;

public class MovingEnemy : Enemy {

    float MoveTimer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();

        MoveTimer += Time.deltaTime;
        if (target != null)
        {
            if (MoveTimer >= 1)
            {
                MoveTimer = 0f;
                GetComponent<NavMeshAgent>().SetDestination(target.position);
            }
        }
	}
}
