using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    MapData theData;

    public void SetMapData(int width, int height, int seed, bool[,] map)
    {
        theData.width = width;
        theData.height = height;
        theData.seed = seed;
        theData.map = new bool[theData.width, theData.height];
    }

    
}
