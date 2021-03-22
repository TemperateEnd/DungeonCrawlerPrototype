using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneratorScript : MonoBehaviour
{
    public MazeObject selectedMaze;
    //public Texture2D map;
    public colourToPrefab[] colourToMazeTile;

    public colourToPrefab[] colourToGameObj;
    public int overallScaleOffset = 1;

    [SerializeField] private int spawnMapNumber;

    void Start() 
    {
        spawnMapNumber = UnityEngine.Random.Range(0, selectedMaze.mazeSpawnTextureArray.Length);
        GenerateLevel();
    }

    //We'll need to start this somehow 
    private void GenerateLevel()
    {
        //Loop through texture width and height
        for(int x = 0; x < selectedMaze.mazeTexture.width; x++)
        {
            for(int z = 0; z < selectedMaze.mazeTexture.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        for(int x = 0; x < selectedMaze.mazeSpawnTextureArray[spawnMapNumber].width; x++)
        {
            for(int z = 0; z < selectedMaze.mazeSpawnTextureArray[spawnMapNumber].height; z++)
            {
                GenerateGameObject(x, z);
            }
        }
    }

    private void GenerateTile(int x, int z)
    {
        Color pixelColor = selectedMaze.mazeTexture.GetPixel(x, z); //Color of pixel within texture

        if(pixelColor.a == 0)
        {
            return; //Because the pixel is transparent, the pixel will be skipped
        }

        foreach(colourToPrefab colorMapping in colourToMazeTile)
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

    private void GenerateGameObject(int x, int z)
    {
        Color pixelColor = selectedMaze.mazeSpawnTextureArray[spawnMapNumber].GetPixel(x, z);

        if (pixelColor.a == 0)
        {
            return; //Skip pixel if pixel is transparent
        }

        foreach(colourToPrefab colorMapping in colourToGameObj)
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