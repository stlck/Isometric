using UnityEngine;
using System.Collections;

public class LockPos : MonoBehaviour {

    Vector3 startPOs;

	// Use this for initialization
	void Start () {
        startPOs = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPOs;

	}
}
