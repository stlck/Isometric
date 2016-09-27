using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBlockLevel : MonoBehaviour {

    public Duplicate BaseBlock;
    public List<BlockElement> BlockElements = new List<BlockElement>();

    // Use this for initialization
    void Start () {
        var bls = Resources.LoadAll<BlockLevel>("BlockLevels");
	    foreach(var be in bls[Random.Range(0, bls.Length)].BlockElements)
        {
            var b = Instantiate(BaseBlock, be.From + transform.position, Quaternion.identity, transform) as Duplicate;
            b.transform.forward = (be.To - be.From).normalized;
            b.x = be.Width;
            b.y = be.Height;
            b.z = (int)Vector3.Distance(be.From, be.To);
        }
	}
	
	
}
