using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Data", menuName = "Procedural Cave Generation/Map Data")]
public class MapData : ScriptableObject
{
    public int width;
    public int height;
    public int seed;
    public bool[,] map;
}
