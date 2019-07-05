using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//generating map data using cellular automata
public class MapGenerator : MonoBehaviour
{
    //dimensions of the map
    [Header("Map Data")]
    public int width;
    public int height;
    public string seed;

    //initialization of the map
    [Header("Map Initialization")]
    [Range(0, 100)]
    public float fillPercentage;

    //for cellular automata
    [Header("Cellular Automata Controls")]
    [Range(0, 10)]
    public int simulationSteps;
    [Range(0, 6)]
    public int creationLimit;
    [Range(0, 6)]
    public int destructionLimit;

    //optional stuff
    [Header("Map Generator Options")]
    public bool generateRandomSeed;
    public bool autoUpdate;

    private Map generatedMap;
    public Map GeneratedMap
    {
        get
        {
            return generatedMap;
        }
    }

    public void GenerateMap()
    {
        InitializeMap();
        CellularAutomata.GenerateMapData(generatedMap, simulationSteps, creationLimit, destructionLimit);
    }

    private void InitializeMap()
    {
        

        //initialize map with new data
        generatedMap = new Map(new Vector2Int(width, height), seed);

        //create a seeded prng
        System.Random prng = new System.Random(seed.GetHashCode());

        //fill the map with walls randomly
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //set all cells at the map's edges as wall
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    generatedMap.Grid[x, y] = true;
                }
                else
                {
                    if (prng.Next(0, 100) <= fillPercentage)
                    {
                        generatedMap.Grid[x, y] = true;
                    }
                    else
                    {
                        generatedMap.Grid[x, y] = false;
                    }
                }
            }
        }
    }

    public void GenerateRandomSeed()
    {
        //randomize seed upon request
        if (generateRandomSeed)
        {
            seed = DateTime.Now.Ticks.ToString();
        }
    }

    public void OnValidate()
    {
        if (width < 1)
        {
            width = 1;
        }
        if (height < 1)
        {
            height = 1;
        }
        if (simulationSteps < 0)
        {
            simulationSteps = 0;
        }
    } 
}