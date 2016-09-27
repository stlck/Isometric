using UnityEngine;
using System.Collections;

public class LerpFloat : MonoBehaviour {

    public FloatEvent Float;
    public float Duration = 1f;
    public float StartAt = 0f;
    public float EndAt = 1f;

    public bool Running = false;
    float timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Running)
        {
            timer += Time.deltaTime;
            Float.Invoke(Mathf.Lerp(StartAt, EndAt, timer/ Duration));

            if(timer >= 1f)
            {
                Running = false;
                timer = 0f;
            }
        }
	}
}
