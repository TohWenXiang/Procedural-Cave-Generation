using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static int mod(int index, int maxSize)
    {
        while (index < 0) index += maxSize;
        return index % maxSize;
    }
}
