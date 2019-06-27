using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellularAutomata
{
    public static void GenerateMapData(MapData mapData, int simulationSteps, int creationLimit, int destructionLimit)
    {
        for (int i = 0; i < simulationSteps; i++)
        {
            mapData.map = SimulationStep(mapData.map, creationLimit, destructionLimit);
        }
    }

    private static bool[,] SimulationStep(bool[,] originalMap, int creationLimit, int destructionLimit)
    {
        //get map data dimensions
        int width = originalMap.GetLength(0);
        int height = originalMap.GetLength(1);

        //create a new map data array so that original data remains clean
        bool[,] updatedMap = new bool[width, height];

        //loop through the map data
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //get neighbouring wall count
                int neighbouringWallCount = GetNeighbouringWallCount(originalMap, new Vector2Int(x, y));

                //if current cell is a wall
                if (originalMap[x, y] == true)
                {
                    //but it has too little neighbouring walls, destroy it, otherwise don't.
                    if (neighbouringWallCount < destructionLimit)
                    {
                        updatedMap[x, y] = false;
                    }
                    else
                    {
                        updatedMap[x, y] = true;
                    }
                }
                //if current cell has no wall
                else
                {
                    //if it has more than a certain amount of neighbouring walls, then create more walls, otherwise don't.
                    if (neighbouringWallCount > creationLimit)
                    {
                        updatedMap[x, y] = true;
                    }
                    else
                    {
                        updatedMap[x, y] = false;
                    }
                }
            }
        }

        return updatedMap;
    }

    private static int GetNeighbouringWallCount(bool[,] mapData, Vector2Int pos)
    {
        int width = mapData.GetLength(0);
        int height = mapData.GetLength(1);
        int neighbouringWallCount = 0;
        List<Vector2Int> neighbouringCells = GetNeighbouringCells(mapData, pos);

        for (int i = 0; i < neighbouringCells.Count; i++)
        {
            if (mapData[neighbouringCells[i].x, neighbouringCells[i].y] == true)
            {
                neighbouringWallCount += 1;
            }
        }


        return neighbouringWallCount;
    }

    public static List<Vector2Int> GetNeighbouringCells(bool[,] mapData, Vector2Int targetCellIndex)
    {
        int width = mapData.GetLength(0);
        int height = mapData.GetLength(1);
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
                else if (neighbouringCellIndex.x >= 0 && neighbouringCellIndex.x < width && neighbouringCellIndex.y >= 0 && neighbouringCellIndex.y < height)
                {
                    //add to list
                    neighbouringCells.Add(neighbouringCellIndex);
                }
                //if cells are out of bounds, wrap around the index
                else
                {
                    neighbouringCells.Add(new Vector2Int(Utility.mod(neighbouringCellIndex.x, width), Utility.mod(neighbouringCellIndex.y, height)));
                }
            }
        }

        return neighbouringCells;
    }
}
