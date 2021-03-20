using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/New Maze Spawn Object", fileName="New Maze Spawn Object")]
public class MazeSpawnObject : ScriptableObject
{
    public Vector3 position;
    public bool positionOccupied;
}
