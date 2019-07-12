﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 position;
    public int vertexIndex = -1;
    
    public Node(Vector3 pos)
    {
        position = pos;
    }
}
