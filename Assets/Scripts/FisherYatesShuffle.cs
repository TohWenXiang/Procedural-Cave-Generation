using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    //return a shuffled array of cell index
    public static List<Vector2Int> FisherYates(List<Vector2Int> input, System.Random randNumGen)
    {
        for (int i = input.Count - 1; i > 0; i--)
        {
            int randomIndex = randNumGen.Next(0, i);

            Vector2Int temp = input[randomIndex];

            input[randomIndex] = input[i];
            input[i] = temp;
        }

        return input;
    }
}

