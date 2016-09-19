using UnityEngine;
using System.Collections;
using Valve.VR;

public class ScaleOnInput : MonoBehaviour {

    public SteamVR_TrackedController trObj;
    public bool master;
    public ScaleOnInput Other;
    //SteamVR_Controller.Device device;
    float deltaDist;
    Vector3 startPos;

    // Use this for initialization
    void Start () {

        //device.GetTouchDown(EVRButtonId.k_EButton_SteamVR_Touchpad);
        //device.GetAxis();
        trObj.PadTouched += TrObj_PadTouched;
        trObj.Gripped += TrObj_Gripped;
    }

    private void TrObj_Gripped(object sender, ClickedEventArgs e)
    {
        Debug.Log(transform.position + " " + Other.transform.position);
        startPos = transform.position;
        deltaDist = Vector3.Distance(transform.position, Other.transform.position);
        
    }

    private void TrObj_PadTouched(object sender, ClickedEventArgs e)
    {
        
    }

    // Update is called once per frame
    void Update () {
        if(trObj.gripped && !Other.trObj.gripped)
        {
            transform.root.localScale = transform.root.localScale + Vector3.one * (deltaDist - Vector3.Distance(transform.position, Other.transform.position));
        }
        if (trObj.gripped && Other.trObj.gripped)
        {
            var p = transform.root.position;
            p.y = (transform.position.y + Other.transform.position.y) / 2;
            transform.root.position = p;
        }

    }
}
