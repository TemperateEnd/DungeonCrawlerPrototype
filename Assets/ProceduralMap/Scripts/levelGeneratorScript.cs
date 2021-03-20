using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneratorScript : MonoBehaviour
{
    public MazeObject selectedMaze;
    //public Texture2D map;
    public colourToPrefab[] colorMappings;
    public int overallScaleOffset = 1;

    public GameObject playerObj;
    public GameObject bossObj;

    public Vector3 playerSpawnPosition;
    public Vector3 bossSpawnPosition;

    public MazeSpawnObject[] chosenPositions;

    void Start() 
    {
        GenerateLevel();
    }

    //We'll need to start this somehow 
    private void GenerateLevel()
    {
        //Loop through texture width and height
        for(int x = 0; x < selectedMaze.map.width; x++)
        {
            for(int z = 0; z < selectedMaze.map.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        for(int i = 0; i < chosenPositions.Length;i++)
        {
            chosenPositions[i] = selectedMaze.mazePositions[UnityEngine.Random.Range(0, selectedMaze.mazePositions.Length)];
            chosenPositions[i].positionOccupied = true;

            if(selectedMaze.mazePositions[UnityEngine.Random.Range(0, selectedMaze.mazePositions.Length)].positionOccupied == true) {
                chosenPositions[i] = selectedMaze.mazePositions[UnityEngine.Random.Range(0, selectedMaze.mazePositions.Length)];  
            }
        }

        playerSpawnPosition = new Vector3(chosenPositions[0].position.x, 0.5f, chosenPositions[0].position.z);
        bossSpawnPosition = new Vector3(chosenPositions[1].position.x, 0.5f, chosenPositions[1].position.z);

        Instantiate(playerObj, playerSpawnPosition, Quaternion.identity);
    }

    private void GenerateTile(int x, int z)
    {
        Color pixelColor = selectedMaze.map.GetPixel(x, z); //Color of pixel within texture

        if(pixelColor.a == 0)
        {
            return; //Because the pixel is transparent, the pixel will be skipped
        }

        foreach(colourToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.colour.Equals(pixelColor))
            {
                colorMapping.prefab.transform.localScale = colorMapping.localScaleOfThisObject;

                Vector3 pos = new Vector3(overallScaleOffset * (x + colorMapping.offsetX), 
                                            colorMapping.prefab.transform.position.y, 
                                            overallScaleOffset * (z + colorMapping.offsetZ));
                Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
            }
        }
    }
}