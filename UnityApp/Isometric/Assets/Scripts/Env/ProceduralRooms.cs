using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ProceduralRooms : ProceduralBlocks {

    //public int MaxWidth = 100;
    //public int MaxHeight = 100;

    public int RoomsMin = 3;
    public int RoomsMax = 8;

    //public string seed;

    //int[,] tiles;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int[,] AddRooms (int[,] map, int width, int height, int RoomsMin, int RoomsMax)
    {
        var rooms = Random.Range(RoomsMin, RoomsMax);

        for (int i = 0; i < rooms; i++)
        {
            ProceduralBlocks.Coord c = new ProceduralBlocks.Coord(Random.Range(0, width), Random.Range(0, height));

            map[c.tileX, c.tileY] = 0;

            var sW = Random.Range(4, 10);
            var sH = Random.Range(4, 10);

            for (int a = c.tileX - sW / 2; a <= c.tileX + sW / 2; a++)
                for (int b = c.tileY - sH / 2; b <= c.tileY + sH / 2; b++)
                {
                    //if ( Mathf.Clamp(a, 0, MaxWidth) == a && Mathf.Clamp(b, 0, MaxHeight) == b)
                    if (a >= 0 && a < width && b >= 0 && b < height)
                    {
                        map[a, b] = 0;
                    }
                }

            // set walls = 3

            //if(c.tileY - sH / 2 >= 0 && c.tileY - sH / 2 < height)
            for (int a = c.tileX - sW / 2; a <= c.tileX + sW / 2; a++)
            {
                if (a >= 0 && a < width && c.tileY - sH / 2 >= 0 && c.tileY - sH / 2 < height)
                {
                    map[a, c.tileY - sH / 2] = 3;
                    Debug.Log("3");
                }
                if (a >= 0 && a < width && c.tileY + sH / 2 >= 0 && c.tileY + sH / 2 < height)
                {
                    map[a, c.tileY + sH / 2] = 3;
                    Debug.Log("3");
                }

            }

            for (int b = c.tileY - sH / 2; b <= c.tileY + sH / 2; b++)
            {
                if (b >= 0 && b < height && c.tileX - sW / 2 >= 0 && c.tileX - sW / 2 < width)
                {
                    map[b, c.tileX - sW / 2] = 3;
                    Debug.Log("3");
                }
                if (b >= 0 && b < height && c.tileX + sW / 2 >= 0 && c.tileX + sW / 2 < width)
                {
                    map[b, c.tileX + sW / 2] = 3;
                    Debug.Log("3");
                }
            }
        }

        

        return map;
    }

    public override int[,] GenerateMap(int w, int h, int smooth = 5)
    {
        base.width = w;
        base.height = h;

        survivingRooms = new List<Room>();
        var rooms = Random.Range(RoomsMin, RoomsMax);
        map = new int[width, height];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                map[i, j] = 1;


        survivingRooms = new List<Room>();

        for (int i = 0; i < rooms; i++)
        {
            ProceduralBlocks.Coord c = new ProceduralBlocks.Coord(Random.Range(0, width), Random.Range(0, height));

            map[c.tileX, c.tileY] = 0;

            var sW = Random.Range(2, 8);
            var sH = Random.Range(2, 8);

            for(int a = c.tileX - sW / 2; a <= c.tileX + sW / 2; a++)
                for(int b = c.tileY - sH / 2; b <= c.tileY + sH / 2; b++)
                {
                    //if ( Mathf.Clamp(a, 0, MaxWidth) == a && Mathf.Clamp(b, 0, MaxHeight) == b)
                    if( a >= 0 && a < width && b >= 0 && b < height)
                        map[a, b] = 0;
                }
            
            //ProcessMap();
        }

        //ProcessMap();

        return map;
    }
}
