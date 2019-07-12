using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public ControlNode topLeft;
    public ControlNode topRight;
    public ControlNode bottomLeft;
    public ControlNode bottomRight;

    public Node centerTop;
    public Node centerRight;
    public Node centerBottom;
    public Node centerLeft;

    public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft)
    {

    }
}
