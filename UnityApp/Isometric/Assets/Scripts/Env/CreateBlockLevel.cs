using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CreateBlockLevel : MonoBehaviour {

    public Duplicate BaseBlock;
    public List<BlockElement> BlockElements = new List<BlockElement>();

    public Vector2 FloorSize = new Vector2(50, 50);
    public int FloorBlockSize = 5;
    public Transform BaseFloorBlock;
    public List<Material> FloorMats;

    public bool Procedural = true;

    // Use this for initialization
    void Start () {
        BaseFloorBlock.GetComponent<MeshRenderer>().material.mainTexture = determineMaterial(-1,-1).mainTexture;// FloorMats[Random.Range(0, FloorMats.Count)];

        if(Procedural)
            spawnProcedural();
        else { 
            var bls = Resources.LoadAll<BlockLevel>("BlockLevels");
	        foreach(var be in bls[Random.Range(0, bls.Length)].BlockElements)
            {
                spawn(be);
            }

            //floor
            var scale = new Vector3(FloorBlockSize, 1, FloorBlockSize);
            for(int i = -(int)FloorSize.x/2; i <= (int)FloorSize.x/2; i += FloorBlockSize)
            {
                for (int j = -(int)FloorSize.y / 2; j <= (int)FloorSize.y / 2; j += FloorBlockSize)
                {
                    var t = (Transform)Instantiate(BaseFloorBlock, transform.position + Vector3.right * i + Vector3.forward*j, Quaternion.identity, transform);
                    t.localScale = scale;

                    //t.GetComponent<MeshRenderer>().material.mainTexture = determineMaterial(i,j).mainTexture;
                }
            }
        }
    }

    Material determineMaterial(int x, int z)
    {
        //var r = Mathf.PerlinNoise(x/FloorSize.x, z/ FloorSize.y) * (float)FloorMats.Count;
        return FloorMats[Random.Range(0, FloorMats.Count)];
    }

    void OnGUI()
    {
        if (Procedural && GUILayout.Button("Remake"))
            spawnProcedural();
    }

	//void spawn(Transform t, int x, int y, int z)
    void spawn(BlockElement be)
    {
        int x = be.Width;
        int y = be.Height;
        int z = (int)Vector3.Distance(be.From, be.To);
        Vector3 start = be.From;
        Vector3 forward = ((be.To - be.From).normalized);
        var scale = BaseBlock.transform.localScale;
        var startB = Instantiate(BaseBlock, be.From + transform.position, Quaternion.identity, transform) as Duplicate;
        startB.transform.forward = forward;

        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
                for (int k = 0; k < z; k++)
                {
                    if (i > 0 || j > 0 || k > 0)
                    {
                        Instantiate(BaseBlock,
                            transform.position +
                            startB.transform.position +
                            startB.transform.up * j * scale.y +
                            startB.transform.right * i * scale.x +
                            startB.transform.forward * k * scale.z,
                            startB.transform.rotation,
                            startB.transform);
                    }
                }

        var nav = startB.gameObject.AddComponent<NavMeshObstacle>();
        nav.center = Vector3.right * ((x / 2) - .5f) + Vector3.up * ((y / 2) - .5f) + Vector3.forward * ((z / 2) - .5f);
        nav.size = new Vector3(x, y, z);
    }

    public ProceduralBlocks pb;
    void spawnProcedural()
    {
        foreach (Transform c in transform)
            Destroy(c.gameObject);

        if(pb != null)
        {
            var scale = new Vector3(FloorBlockSize, 1, FloorBlockSize);
            var m = pb.GenerateMap((int)FloorSize.x, (int) FloorSize.y, 2);
            for (int i = 0; i < pb.width; i++)
                for (int j = 0; j < pb.height; j++)
                {
                    if (m[i, j] == 0)
                    {
                        if (pb.survivingRooms.Any(n => n.tiles.Contains(new ProceduralBlocks.Coord(i, j))))
                            ;
                        var t = (Transform)Instantiate(BaseFloorBlock, Vector3.right * FloorBlockSize * i + Vector3.forward * FloorBlockSize * j, BaseFloorBlock.rotation, transform);
                        t.Rotate(Vector3.up, Random.Range(0, 4) * 90, Space.World);
                        t.localScale = FloorBlockSize * Vector3.one;//scale;
                    }
                }
        }
    }
}
