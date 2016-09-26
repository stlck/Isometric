using UnityEngine;
using System.Collections;
using Valve.VR;

public class ScaleOnInput : MonoBehaviour {

    public SteamVR_TrackedController trObj;
    public bool master;
    public ScaleOnInput Other;
    public AnimationCurve YCurve;

    float deltaDist;
    Vector3 startPos;

    // Use this for initialization
    void Start () {

        //device.GetTouchDown(EVRButtonId.k_EButton_SteamVR_Touchpad);
        //device.GetAxis();
        startPos = transform.position; 
        trObj.PadTouched += TrObj_PadTouched;
        trObj.Gripped += TrObj_Gripped;
    }

    private void TrObj_Gripped(object sender, ClickedEventArgs e)
    {
        Debug.Log(transform.position + " " + Other.transform.position);
        deltaDist = Vector3.Distance(transform.position, Other.transform.position);
    }

    private void TrObj_PadTouched(object sender, ClickedEventArgs e)
    {
        
    }

    // Update is called once per frame
    void Update () {
        if(trObj.gripped && !Other.trObj.gripped)
        {
            var scale = transform.root.localScale + Vector3.one * (deltaDist - Vector3.Distance(transform.position, Other.transform.position));
            scale = Vector3.Min(scale, Vector3.one * 30);
            scale = Vector3.Max(Vector3.one * 10, scale);
            
            transform.root.localScale = scale;
        }

        if (master && trObj.gripped && Other.trObj.gripped)
        {
            var p = transform.root.position;
            p.y = YCurve.Evaluate(2-transform.localPosition.y);/*(transform.localPosition.y * transform.root.localScale.y);
            p.y += startPos.y*2;*/
            transform.root.position = p;
        }

    }
}
