﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        //if inspector updates due to changes inside it.
        if (DrawDefaultInspector())
        {
            //check if auto update is enabled
            if (mapGen.autoUpdate == true)
            {
                //if seed is to be randomized
                if (mapGen.generateRandomSeed)
                {
                    mapGen.GenerateRandomSeed();
                }
                //generate Map again
                mapGen.GenerateMap();
            }
        }

        //if generate cave map button is pressed
        if (GUILayout.Button("Generate Cave Map"))
        {
            //generate Map
            mapGen.GenerateMap();
        }
    }
}