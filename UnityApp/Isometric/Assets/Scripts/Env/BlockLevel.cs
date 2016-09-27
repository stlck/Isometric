using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class BlockLevel : ScriptableObject {

    public List<BlockElement> BlockElements = new List<BlockElement>();

}

[System.Serializable]
public class BlockElement
{
    public Vector3 From;
    public Vector3 To;
    public int Height = 2;
    public int Width = 1;
}