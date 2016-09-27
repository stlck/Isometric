using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

    public List<GameObject> VRActive = new List<GameObject>();
    public List<GameObject> VRNotActive = new List<GameObject>();

	// Use this for initialization
	void Start () {
	    if(Valve.VR.OpenVR.IsHmdPresent())
        {
            VRActive.ForEach(m => m.gameObject.SetActive(true));
        }
        else
        {
            VRNotActive.ForEach(m => m.gameObject.SetActive(true));
        }
    }
}
