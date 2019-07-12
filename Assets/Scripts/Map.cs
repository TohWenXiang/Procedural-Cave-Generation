using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private MapData mapData;
    public Vector2Int Size
    {
        get
        {
            return mapData.size;
        }
    }

    public bool[,] Grid
    {
        set
        {
            mapData.grid = value;
        }
        get
        {
            return mapData.grid;
        }
    }

    public Map()
    {
        mapData = new MapData();
        mapData.size = new Vector2Int(25, 25);
        mapData.grid = new bool[mapData.size.x, mapData.size.y];
        mapData.seed = "Wen Xiang";
    }

    public Map(Vector2Int size, string seed)
    {
        mapData = new MapData();
        mapData.size = size;
        mapData.grid = new bool[mapData.size.x, mapData.size.y];
        mapData.seed = seed;
    }

    public int GetNeighbouringWallCount(Vector2Int pos)
    {
        int neighbouringWallCount = 0;
        List<Vector2Int> neighbouringCells = GetNeighbouringCells(pos);

        for (int i = 0; i < neighbouringCells.Count; i++)
        {
            if (mapData.grid[neighbouringCells[i].x, neighbouringCells[i].y] == true)
            {
                neighbouringWallCount += 1;
            }
        }

        return neighbouringWallCount;
    }

    public List<Vector2Int> GetNeighbouringCells(Vector2Int targetCellIndex)
    {
        List<Vector2Int> neighbouringCells = new List<Vector2Int>();

        //loop through the 3 by 3 centered on the current cell
        for (int a = -1; a < 2; a++)
        {
            for (int b = -1; b < 2; b++)
            {
                Vector2Int neighbouringCellIndex = new Vector2Int(targetCellIndex.x + a, targetCellIndex.y + b);

                //reject ourselves, we only want the neighbouring 8 cells
                if (neighbouringCellIndex == targetCellIndex)
                {
                    continue;
                }
                //if cells are within bounds
                else if (neighbouringCellIndex.x >= 0 && neighbouringCellIndex.x < mapData.size.x && neighbouringCellIndex.y >= 0 && neighbouringCellIndex.y < mapData.size.y)
                {
                    //add to list
                    neighbouringCells.Add(neighbouringCellIndex);
                }
                //if cells are out of bounds, wrap around the index
                else
                {
                    neighbouringCells.Add(Utility.WrapAroundIndex(neighbouringCellIndex, mapData.size));
                }
            }
        }

        return neighbouringCells;
    }
}
