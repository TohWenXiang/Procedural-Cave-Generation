using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNode : Node
{
    public bool active;
    public Node aboveNode;
    public Node rightNode;

    public ControlNode(Vector3 pos, bool _active, float squareSize) : base(pos)
    {
        active = _active;
        aboveNode = new Node(pos + (Vector3.forward * (squareSize * 0.5f)));
        rightNode = new Node(pos + (Vector3.right * (squareSize * 0.5f)));
    }
}
