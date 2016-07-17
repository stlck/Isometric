using UnityEngine;
using System.Collections;

public class IncreaseSize : MonoBehaviour {

    public Vector3 EndSize;
    Vector3 StartSize;
    public float OverTime = 1;
    float timer = 0;

	// Use this for initialization
	void Start () {
	    StartSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.localScale != EndSize)
        {
            timer += Time.deltaTime / OverTime;
            transform.localScale = Vector3.Lerp(StartSize, EndSize, timer);
        }
	}
}
