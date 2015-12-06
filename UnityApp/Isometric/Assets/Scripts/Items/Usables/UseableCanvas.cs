using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class UseableCanvas : MonoBehaviour {

    static UseableCanvas instance;
    public static UseableCanvas Instance
    {
        get
        {
            return instance;
        }
    }
    Useable target;
    public Vector3 Offset;

    public StringEvent UsableName;

	// Use this for initialization
	void Start () {
        instance = this;
        gameObject.SetActive(false);
	}
	
	public void Show(Useable t) {
        target = t;
        UsableName.Invoke(t.name);
        transform.position = target.transform.position + Offset;

        gameObject.SetActive(true);
	}

    public void Dismiss()
    {
        gameObject.SetActive(false);
    }

    public void UseItem(int index)
    {
        target.Use(index);
        Destroy(target.gameObject);
        Dismiss();
    }
}

[System.Serializable]
public class StringEvent:UnityEvent<string>
{

}