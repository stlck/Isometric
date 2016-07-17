using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class OnScreenGUI : MonoBehaviour {

    public static List<Action> ToDo = new List<Action>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        ToDo.ForEach((a) => a());
    }
}
