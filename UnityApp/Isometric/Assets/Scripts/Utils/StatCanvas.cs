using UnityEngine;
using System.Collections;

public class StatCanvas : MonoBehaviour {

    private static StatCanvas instance;
    public static StatCanvas GetInstance
    {
        get
        {
            if (instance == null)
                instance = Resources.Load<StatCanvas>("StatCanvas");
            return Instantiate(instance);
        }
    }

    public FloatEvent HealthUpdate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
