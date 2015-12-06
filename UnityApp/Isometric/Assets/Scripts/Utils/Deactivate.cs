using UnityEngine;
using System.Collections;

public class Deactivate : MonoBehaviour {

    public float DisableAfter = .5f;
    float time = 0;
	// Use this for initialization
	void OnEnable () {
        time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > DisableAfter)
            gameObject.SetActive(false);
	}
}
