using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    private Map mapDisplay;

    [Header("Neighbouring Cells Controls")]
    public Vector2Int targetedCellIndex;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            mapDisplay = FindObjectOfType<MapGenerator>().GeneratedMap;
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex, this);
        }
    }

    public void OnDrawGizmos()
    {
        try
        {
            for (int x = 0; x < mapDisplay.Size.x; x++)
            {
                for (int y = 0; y < mapDisplay.Size.y; y++)
                {
                    if (mapDisplay.Grid[x, y] == true)
                    {
                        Gizmos.color = Color.black;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }

                    Vector3 pos = new Vector3(-(mapDisplay.Size.x / 2) + x + 0.5f, 0, -(mapDisplay.Size.y / 2) + y + 0.5f);

                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }

            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(new Vector3(-(mapDisplay.Size.x / 2) + Utility.mod(targetedCellIndex.x, mapDisplay.Size.x) + 0.5f, 0, -(mapDisplay.Size.y / 2) + Utility.mod(targetedCellIndex.y, mapDisplay.Size.y) + 0.5f), Vector3.one);

            List<Vector2Int> neighbouringCells;
            neighbouringCells = mapDisplay.GetNeighbouringCells(targetedCellIndex);

            Vector3 position = Vector3.zero;
            for (int i = 0; i < neighbouringCells.Count; i++)
            {
                position = new Vector3(-(mapDisplay.Size.x / 2) + neighbouringCells[i].x + 0.5f, 0, -(mapDisplay.Size.y / 2) + neighbouringCells[i].y + 0.5f);

                if (mapDisplay.Grid[neighbouringCells[i].x, neighbouringCells[i].y] == true)
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
        catch (System.Exception ex)
        {
            if (ex is System.NullReferenceException)
            {
                return;
            }
            Debug.Log(ex, this);
        }
    }
}
