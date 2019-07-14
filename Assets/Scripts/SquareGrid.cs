using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid
{
    public Square[,] squares;

    public SquareGrid(bool[,] map, float squareSize)
    {
        int nodeCountX = map.GetLength(0);
        int nodeCountY = map.GetLength(1);

        float mapWidth = nodeCountX * squareSize;
        float mapHeight = nodeCountY * squareSize;

        ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

        for (int x = 0; x < nodeCountX; x++)
        {
            for (int y = 0; y < nodeCountY; y++)
            {
                //calculate the position of our first control node
                Vector3 pos = new Vector3((-mapWidth * 0.5f) + (x * squareSize) + (squareSize * 0.5f), 0, (-mapHeight * 0.5f) + (y * squareSize) + (squareSize * 0.5f));
                controlNodes[x, y] = new ControlNode(pos, map[x, y], squareSize);
            }
        }

        squares = new Square[nodeCountX - 1, nodeCountY - 1];

        for (int x = 0; x < nodeCountX - 1 ; x++)
        {
            for (int y = 0; y < nodeCountY - 1; y++)
            {
                squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
            }
        }
    }

    
}
