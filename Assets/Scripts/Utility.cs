using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static Vector2Int WrapAroundIndex(Vector2Int index, Vector2Int maxSize)
    {
        return new Vector2Int(Mod(index.x, maxSize.y), Mod(index.y, maxSize.y));
    }

    public static int Mod(int index, int maxSize)
    {
        while (index < 0) index += maxSize;
        return index % maxSize;
    }
}
