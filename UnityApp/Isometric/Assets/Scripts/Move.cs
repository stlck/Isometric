using UnityEngine;
using System.Collections;
using Valve.VR;

public class Move : MonoBehaviour {

    public float MaxSpeed;
    public float JumpTime;
    Rigidbody rb;
    bool jumping;
    float jumpTimer;

    //public Vector3 HorizontalInput;
    //public Vector3 VerticalInput;
    public Vector3 JumpInput;

    public Animator Animator;
    public Transform MoveDev;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        //Vector3 dir = ((VerticalInput * Input.GetAxis("Vertical") + HorizontalInput * Input.GetAxis("Horizontal")));'
        Vector3 dir = CustomInput.Instance.Direction;// transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        if (OpenVR.IsHmdPresent() && MoveDev != null)
        {
            if (MoveDev.GetComponent<SteamVR_TrackedController>().triggerPressed)
            {
                var d = MoveDev.position - transform.position;
                d.Normalize();
                d.y = transform.position.y;
                dir = d;
            }
            else
                dir = Vector3.zero;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumping = true;
                Animator.SetTrigger("Jump");
            }

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
        }

        Animator.SetFloat("Forward", transform.InverseTransformVector(dir).normalized.z);// Input.GetAxis("Vertical"));
        Animator.SetFloat("Side", transform.InverseTransformVector(dir).normalized.x);// Input.GetAxis("Horizontal"));
        Animator.SetBool("Move", dir != Vector3.zero);

        //rb.MovePosition(transform.position + dir * MaxSpeed * Time.fixedDeltaTime);
        rb.AddForce(dir * MaxSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
