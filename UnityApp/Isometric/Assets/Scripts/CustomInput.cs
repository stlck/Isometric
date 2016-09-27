using UnityEngine;
using System.Collections;
using Valve.VR;

public class CustomInput : MonoBehaviour {

    public Vector3 Direction;

    private static CustomInput instance;
    public static CustomInput Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject().AddComponent<CustomInput>();
            }
            return instance;
        }
    }
    int moveDeviceId;


    // Use this for initialization
    void Start () {
        if (OpenVR.IsHmdPresent())
        {
            moveDeviceId = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
            //if (ItemHandler.UseItem(MyPlayer.MyRotate.LastTarget))
            //    StartColor.a += .5f;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (OpenVR.IsHmdPresent())
        {
            var dev = SteamVR_Controller.Input(moveDeviceId);
            {
                var pos = dev.transform.pos;
                Direction = (pos).normalized;
                Direction.y = MyPlayer.Instance.transform.position.y;
                
                //Debug.Log("VR POS Dir: " + pos + " - " + MyPlayer.Instance.transform.position + " " + Direction);
            }
            //else
            //    Direction = Vector3.zero;
        }
        else
        {
            Direction = Vector3.forward * Input.GetAxis("Vertical") / 2 -
                Vector3.forward * Input.GetAxis("Horizontal") / 2 +
                Vector3.right * Input.GetAxis("Horizontal") / 2 +
                Vector3.right * Input.GetAxis("Vertical") / 2;
            Direction.Normalize();
        }
    }
}
