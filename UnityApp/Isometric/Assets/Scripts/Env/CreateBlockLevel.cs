using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBlockLevel : MonoBehaviour {

    public Duplicate BaseBlock;
    public List<BlockElement> BlockElements = new List<BlockElement>();

    // Use this for initialization
    void Start () {
	    foreach(var be in BlockElements)
        {
            var b = Instantiate(BaseBlock, be.From + transform.position, Quaternion.identity, transform) as Duplicate;
            b.transform.forward = (be.To - be.From).normalized;
            b.x = be.Width;
            b.y = be.Height;
            b.z = (int)Vector3.Distance(be.From, be.To);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    [System.Serializable]
    public class BlockElement
    {
        public Vector3 From;
        public Vector3 To;
        public int Height;
        public int Width;
    }
}
