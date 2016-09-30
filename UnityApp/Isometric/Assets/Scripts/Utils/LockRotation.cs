using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

    Vector3 eulers;

    void Awake()
    {
        eulers = transform.eulerAngles;
    }

	// Update is called once per frame
	void LateUpdate () {
        transform.eulerAngles = eulers;
	}
}
