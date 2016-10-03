using UnityEngine;
using System.Collections;
using Valve.VR;

public class Rotate : MonoBehaviour {

    public float speed;
    public LayerMask HitMask;
    public Transform Origin;
    public Vector3 LastTarget;
    public Transform ShootPoint;

    int rotateDeviceId;
    public SteamVR_Controller.Device dev;
    void Start()
    {
        if (OpenVR.IsHmdPresent())
        {
            rotateDeviceId = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
            //if (ItemHandler.UseItem(MyPlayer.MyRotate.LastTarget))
            //    StartColor.a += .5f;
        }
    }

    // Update is called once per frame
    void Update () {

        var playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Origin != null && Origin.gameObject.active)
        //if (OpenVR.IsHmdPresent())
         {
            //var p = SteamVR_Controller.Input(rotateDeviceId).transform.TransformPoint(SteamVR_Controller.Input(rotateDeviceId).transform.pos);
            //ray = new Ray(p, SteamVR_Controller.Input(rotateDeviceId).transform.rot.eulerAngles);
            //Debug.Log("P : " + p);
            ray = new Ray(Origin.position, Origin.forward);
        }

        RaycastHit hit;

        //if (Physics.SphereCast(ray, 2, out hit, 200, HitMask))
        if(Physics.Raycast(ray,out hit, HitMask))
        {
            var targetPoint = hit.point;// ray.GetPoint(hitdist);
            targetPoint.y = transform.position.y;
            var sPoint = hit.point;

            if (hit.collider.tag == "Floor")
                sPoint += targetPoint + Vector3.up;
            /*if(hit.collider.tag != "Floor")
            {
                ShootPoint.LookAt(hit.point);
                //targetPoint = hit.transform.position;
            }
            else 
            {
                //targetPoint.y += 1f;
                //targetPoint.y = transform.position.y;
                ShootPoint.LookAt(targetPoint + Vector3.up);

            }*/
            ShootPoint.LookAt(sPoint);

            LastTarget = targetPoint;
            Debug.Log("HIT : " + hit.point + " . T: " + targetPoint + " . tr :" + transform.position +  " . s :" + sPoint);

            transform.LookAt(targetPoint);//rotation = Quaternion.LookRotation(targetPoint - transform.position);
        }

        /*if (Physics.Raycast(ray, out hit, 100, HitMask) && Vector3.Distance( hit.point,transform.position) > 4)
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
        }*/
	}



}
