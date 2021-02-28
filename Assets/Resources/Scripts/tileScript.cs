using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public bool mazeStart;
    public bool mazeEnd;

    [Header("Directional Booleans")]
    public bool canMoveNorth;
    public bool canMoveEast;
    public bool canMoveSouth;
    public bool canMoveWest;
}