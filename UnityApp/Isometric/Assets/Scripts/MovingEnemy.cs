using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MovingEnemy : Enemy {

    float MoveTimer = 0f;

    bool moving = false;

    NavMeshAgent agent;
    Animator animator;



    public override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Forward", moving);
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
                agent.SetDestination(target.position);
            }
        }

        if(moving && agent.velocity == Vector3.zero)
        {
            moving = false;
            animator.SetBool("Forward", moving);
        }
        else if(!moving && agent.velocity != Vector3.zero)
        {
            moving = true;
            animator.SetBool("Forward", moving);
        }
	}

}

[System.Serializable]
public class BoolUpdate : UnityEvent<bool>{

}