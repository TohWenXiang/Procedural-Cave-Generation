using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public MapData mapData;

    [Header("Neighbouring Cells Controls")]
    public Vector2Int targetedCellIndex;

    public void OnDrawGizmos()
    {
        if (mapData != null && mapData.map != null)
        {
            for (int x = 0; x < mapData.width; x++)
            {
                for (int y = 0; y < mapData.height; y++)
                {
                    if (mapData.map[x, y] == true)
                    {
                        Gizmos.color = Color.black;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }

                    Vector3 pos = new Vector3(-(mapData.width / 2) + x + 0.5f, 0, -(mapData.height / 2) + y + 0.5f);

                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }

            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(new Vector3(-(mapData.width / 2) + Utility.mod(targetedCellIndex.x, mapData.width) + 0.5f, 0, -(mapData.height / 2) + Utility.mod(targetedCellIndex.y, mapData.width) + 0.5f), Vector3.one);

            List<Vector2Int> neighbouringCells;
            neighbouringCells = CellularAutomata.GetNeighbouringCells(mapData.map, targetedCellIndex);

            Vector3 position = Vector3.zero;
            for (int i = 0; i < neighbouringCells.Count; i++)
            {
                position = new Vector3(-(mapData.width / 2) + neighbouringCells[i].x + 0.5f, 0, -(mapData.height / 2) + neighbouringCells[i].y + 0.5f);

                if (mapData.map[neighbouringCells[i].x, neighbouringCells[i].y] == true)
                {
                    Gizmos.color = Color.magenta;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                Gizmos.DrawCube(position, Vector3.one);
            }
        }
    }
}
