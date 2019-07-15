using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    //return a shuffled array of cell index
    static Vector2Int[,] FisherYatesShuffle(Vector2Int[,] unOccupiedCellIndex, System.Random randNumGen)
    {
        Vector2Int[,] shuffledUnOccupiedCellIndex;
        //start from the last item and moving towards the start
        for (int y = unOccupiedCellIndex.GetLength(1) - 1; y > 0; y--)
        {
            for (int x = unOccupiedCellIndex.GetLength(0) - 1; x > 0; x--)
            {
                //get a random cell index
                Vector2Int randomCellIndex = new Vector2Int(randNumGen.Next(0, x + 1), randNumGen.Next(0, y + 1));
            }
        }
    }
}

