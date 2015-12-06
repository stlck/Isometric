using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float MaxSpeed;
    public float JumpTime;
    Rigidbody rb;
    bool jumping;
    float jumpTimer;

    public Vector3 HorizontalInput;
    public Vector3 VerticalInput;
    public Vector3 JumpInput;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        Vector3 dir = (VerticalInput * Input.GetAxis("Vertical") + HorizontalInput * Input.GetAxis("Horizontal"));
        
        if(Input.GetButtonDown("Jump"))
            jumping = true;

        if (jumping && jumpTimer <= JumpTime)
        {
            jumpTimer += Time.fixedDeltaTime;
            dir += JumpInput;
        }
        else
        {
            jumping = false;
            jumpTimer = 0f;
        }

        rb.MovePosition(transform.position + dir * MaxSpeed * Time.fixedDeltaTime);
    }
}
