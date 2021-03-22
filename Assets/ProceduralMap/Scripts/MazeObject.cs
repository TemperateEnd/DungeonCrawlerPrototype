using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/New Maze", fileName="New Maze")]
public class MazeObject : ScriptableObject
{
    public Texture2D mazeTexture;
    public Texture2D[] mazeSpawnTextureArray;
}