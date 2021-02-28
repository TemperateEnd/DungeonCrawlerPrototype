using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class proceduralMazeGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public List<GameObject> testingList;
    public GameObject[,] mazeCells;

    [Range(5, 15)]
    public int mazeWidth;

    [Range(5, 15)]
    public int mazeHeight;
    public int startX;
    public int startZ;
    public int endX;
    public int endZ;
    public GameObject player;
    
    void Awake() 
    {
        startX = Random.Range(0, (mazeWidth-1));
        startZ = Random.Range(0, (mazeHeight-1));

        endX = Random.Range(0, (mazeWidth-1));
        endZ = Random.Range(0, (mazeHeight-1));
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Resources.Load<GameObject>("Prefabs/playerObj");
        tilePrefabs = Resources.LoadAll<GameObject>("Prefabs/mazeTiles");

        foreach(GameObject i in tilePrefabs)
        {
            testingList.Add(i);
        }        

        GameObject maze = new GameObject("Maze");

        mazeCells = new GameObject[mazeHeight, mazeWidth];

        for(int i = 0; i < mazeHeight; i++)
        {
            for(int j = 0; j < mazeWidth; j++)
            {
                mazeCells[i,j] = (GameObject) Instantiate(testingList[Random.Range(0, testingList.Count)], new Vector3(j, 0, i), Quaternion.identity, maze.transform);
                mazeCells[i,j].name = ("Cell " + i + ", " + j);

                //Check to see if tile is start or end of maze
                if(i == startX && j == startZ)
                {
                    mazeCells[i,j].GetComponent<tileScript>().mazeStart = true;
                    mazeCells[i,j].name = ("Cell " + i + ", " + j + ": Start");
                }

                else if (i == endX && j == endZ)
                {
                    mazeCells[i,j].GetComponent<tileScript>().mazeEnd = true;
                    mazeCells[i,j].name = ("Cell " + i + ", " + j + ": End");
                }
            }
        }

        //GameObject playerInstance = Instantiate(player, new Vector3(startX, 0, startZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GenerateMaze();
        }
    }

    void GenerateMaze()
    {
        GameObject prevMaze = GameObject.Find("Maze");
        Destroy(prevMaze);
        GameObject newMaze = new GameObject("Maze");

        mazeCells = new GameObject[mazeHeight, mazeWidth];

        for(int i = 0; i < mazeHeight; i++)
        {
            for(int j = 0; j < mazeWidth; j++)
            {
                mazeCells[i,j] = (GameObject) Instantiate(testingList[Random.Range(0, testingList.Count)], new Vector3(j, 0, i), Quaternion.identity, newMaze.transform);
                mazeCells[i,j].name = ("Cell " + i + ", " + j);

                //Check to see if tile is start or end of maze
                if(i == startX && j == startZ)
                {
                    mazeCells[i,j].GetComponent<tileScript>().mazeStart = true;
                    mazeCells[i,j].name = ("Cell " + i + ", " + j + ": Start");
                }

                else if (i == endX && j == endZ)
                {
                    mazeCells[i,j].GetComponent<tileScript>().mazeEnd = true;
                    mazeCells[i,j].name = ("Cell " + i + ", " + j + ": End");
                }
            }
        }

    }
}
