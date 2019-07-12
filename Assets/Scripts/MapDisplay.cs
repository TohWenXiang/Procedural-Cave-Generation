using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    private MapGenerator mapDisplay;

    [Header("Neighbouring Cells Controls")]
    public Vector2Int targetedCellIndex;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            mapDisplay = GameObject.Find("Map Generator").GetComponent<MapGenerator>();
        }
        catch (System.NullReferenceException nullEx)
        {
            Debug.LogException(nullEx, this);
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
            Map theMap = mapDisplay.GeneratedMap;

            for (int x = 0; x < theMap.Size.x; x++)
            {
                for (int y = 0; y < theMap.Size.y; y++)
                {
                    if (theMap.Grid[x, y] == true)
                    {
                        Gizmos.color = Color.black;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }

                    Vector3 pos = new Vector3(-(theMap.Size.x / 2) + x + 0.5f, 0, -(theMap.Size.y / 2) + y + 0.5f);

                    Gizmos.DrawCube(pos, Vector3.one);
                }
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
