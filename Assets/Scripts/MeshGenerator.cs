using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public SquareGrid squareGrid;

    public void GenerateMesh(bool[,] map, float squareSize)
    {
        squareGrid = new SquareGrid(map, squareSize);
    }

    private void OnDrawGizmos()
    {
        if (squareGrid != null)
        {
            for (int x = 0; x < squareGrid.squares.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < squareGrid.squares.GetLength(1) - 1; y++)
                {
                    Gizmos.color = (squareGrid.squares[x, y].topLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGrid.squares[x, y].topLeft.position, (Vector3.one * 0.4f));

                    Gizmos.color = (squareGrid.squares[x, y].topRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGrid.squares[x, y].topRight.position, (Vector3.one * 0.4f));

                    Gizmos.color = (squareGrid.squares[x, y].bottomRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGrid.squares[x, y].bottomRight.position, (Vector3.one * 0.4f));

                    Gizmos.color = (squareGrid.squares[x, y].bottomLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube(squareGrid.squares[x, y].bottomLeft.position, (Vector3.one * 0.4f));

                    Gizmos.color = Color.gray;
                    Gizmos.DrawCube(squareGrid.squares[x, y].centerTop.position, (Vector3.one * 0.15f));
                    Gizmos.DrawCube(squareGrid.squares[x, y].centerRight.position, (Vector3.one * 0.15f));
                    Gizmos.DrawCube(squareGrid.squares[x, y].centerBottom.position, (Vector3.one * 0.15f));
                    Gizmos.DrawCube(squareGrid.squares[x, y].centerLeft.position, (Vector3.one * 0.15f));

                }
            }
        }
    }
}
