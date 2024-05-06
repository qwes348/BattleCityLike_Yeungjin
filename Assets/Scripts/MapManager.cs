using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject pf_iron;
    public GameObject pf_brick;
    public GameObject pf_heart;

    private int[][] map_00;
    private int[][] map_01;
    private List<int[][]> mapsList;
    private List<GameObject> spawnedMapObjects;
    private int[][] currentMapArr;

    public static MapManager Instance { get; private set; }


    private void Awake()
    {
        mapsList = new List<int[][]>();
        spawnedMapObjects = new List<GameObject>();

        Instance = this;

        map_00 = new int[15][]
{
                    //0   1   2   3   4   5   6   7   8   9   10  11  12  13  14
            new int[]{1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1}, // 0
            new int[]{1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1}, // 1
            new int[]{1,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  1}, // 2
            new int[]{1,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  1}, // 3
            new int[]{1,  0,  2,  0,  2,  0,  2,  1,  2,  0,  2,  0,  2,  0,  1}, // 4
            new int[]{1,  0,  2,  0,  2,  0,  0,  0,  0,  0,  2,  0,  2,  0,  1}, // 5
            new int[]{1,  0,  0,  0,  0,  0,  2,  0,  2,  0,  0,  0,  0,  0,  1}, // 6
            new int[]{1,  1,  0,  2,  2,  0,  0,  0,  0,  0,  2,  2,  0,  1,  1}, // 7
            new int[]{1,  0,  0,  0,  0,  0,  2,  0,  2,  0,  0,  0,  0,  0,  1}, // 8
            new int[]{1,  0,  2,  0,  2,  0,  2,  2,  2,  0,  2,  0,  2,  0,  1}, // 9
            new int[]{1,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  1}, // 10
            new int[]{1,  0,  2,  0,  2,  0,  0,  0,  0,  0,  2,  0,  2,  0,  1}, // 11
            new int[]{1,  0,  2,  0,  2,  0,  2,  2,  2,  0,  2,  0,  2,  0,  1}, // 12
            new int[]{1,  0,  0,  0,  0,  0,  2,  3,  2,  0,  0,  0,  0,  0,  1}, // 13
            new int[]{1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1}, // 14
};

        map_01 = new int[][]
        {
                    //0   1   2   3   4   5   6   7   8   9   10  11  12  13  14
            new int[]{1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1}, // 0
            new int[]{1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1}, // 1
            new int[]{1,  0,  2,  0,  2,  0,  0,  0,  2,  0,  2,  0,  2,  0,  1}, // 2
            new int[]{1,  0,  0,  0,  2,  0,  1,  0,  2,  0,  2,  0,  0,  0,  1}, // 3
            new int[]{1,  0,  0,  0,  2,  0,  1,  0,  2,  2,  2,  0,  0,  0,  1}, // 4
            new int[]{1,  0,  2,  0,  2,  0,  0,  0,  0,  0,  2,  0,  2,  0,  1}, // 5
            new int[]{1,  0,  2,  0,  0,  0,  2,  0,  2,  0,  0,  0,  2,  2,  1}, // 6
            new int[]{1,  0,  0,  2,  2,  0,  0,  0,  0,  0,  2,  2,  0,  1,  1}, // 7
            new int[]{1,  1,  2,  0,  0,  0,  2,  0,  2,  0,  0,  0,  0,  2,  1}, // 8
            new int[]{1,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  2,  2,  2,  1}, // 9
            new int[]{1,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  0,  2,  2,  1}, // 10
            new int[]{1,  0,  2,  0,  2,  0,  0,  0,  0,  0,  2,  0,  2,  0,  1}, // 11
            new int[]{1,  0,  2,  0,  2,  0,  2,  2,  2,  0,  0,  0,  2,  0,  1}, // 12
            new int[]{1,  0,  2,  0,  0,  0,  2,  3,  2,  0,  0,  0,  0,  0,  1}, // 13
            new int[]{1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1}, // 14
        };

        mapsList.Add(map_00);
        mapsList.Add(map_01);

        //SpawnMap(1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnMap(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnMap(1);
        }
    }

    public void SpawnMap(int mapIndex)
    {
        if (spawnedMapObjects != null && spawnedMapObjects.Count > 0)
            DestroyMap();

        int[][] mapArray = mapsList[mapIndex];

        for (int i = 0; i < mapArray.Length; i++)
        {
            for (int j = 0; j < mapArray[i].Length; j++)
            {
                GameObject go_temp = new GameObject();
                if (mapArray[i][j] == 1)
                {
                    go_temp = Instantiate(pf_iron);
                }
                if (mapArray[i][j] == 2)
                {
                    go_temp = Instantiate(pf_brick);
                }
                if (mapArray[i][j] == 3)
                {
                    go_temp = Instantiate(pf_heart);
                }
                go_temp.transform.position = new Vector3((j * 2) - 14, -3.5f, 14 - (i * 2));
                spawnedMapObjects.Add(go_temp);
            }
        }

        currentMapArr = mapArray;
    }

    private void DestroyMap()
    {
        foreach(var go in spawnedMapObjects)
        {
            if (go != null)
                Destroy(go);
        }

        spawnedMapObjects.Clear();
    }

    /// <summary>
    /// ÇöÀç ¸ÊÀÇ 0À¸·Î ¼³Á¤µÈ ºó °ø°£ Áß ·£´ý ÁÂÇ¥¸¦ ¹Þ¾Æ¿È
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomEmptyPoint()
    {
        List<Vector2> emptyCoords = new List<Vector2>();
        for (int x = 0; x < currentMapArr.Length; x++)
        {
            for (int y = 0; y < currentMapArr[x].Length; y++)
            {
                if(currentMapArr[x][y] == 0)
                    emptyCoords.Add(new Vector2(x, y));
            }
        }

        Vector2 pickedCoord = emptyCoords[Random.Range(0, emptyCoords.Count)];
        Vector3 worldPos = new Vector3((pickedCoord.y * 2) - 14, -3.5f, 14 - (pickedCoord.x * 2));
        return worldPos;
    }
}
