using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float speed;
    public LayerMask HitMask;
	
	// Update is called once per frame
	void Update () {

        var playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, HitMask) && Vector3.Distance( hit.point,transform.position) > 4)
        {
            var targetPoint = hit.point;// ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        // If the ray is parallel to the plane, Raycast will return false.
        else if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            var targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
	}



}
