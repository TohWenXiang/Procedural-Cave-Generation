using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellularAutomata
{
    public static void GenerateMapData(Map theMap, int simulationSteps, int creationLimit, int destructionLimit)
    {
        for (int i = 0; i < simulationSteps; i++)
        {
            SimulationStep(theMap, creationLimit, destructionLimit);
        }
    }

    private static void SimulationStep(Map theMap, int creationLimit, int destructionLimit)
    {
        //create a new map data array so that original data remains clean
        bool[,] updatedMap = new bool[theMap.Size.x, theMap.Size.y];

        //loop through the map data
        for (int x = 0; x < theMap.Size.x; x++)
        {
            for (int y = 0; y < theMap.Size.y; y++)
            {
                //get neighbouring wall count
                int neighbouringWallCount = theMap.GetNeighbouringWallCount(new Vector2Int(x, y));

                //if current cell is a wall
                if (theMap.Grid[x, y] == true)
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
        theMap.Grid = updatedMap;
    }
}
