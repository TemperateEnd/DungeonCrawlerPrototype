using UnityEngine;

[System.Serializable]
public class colourToPrefab
{
    public Color colour; //Match object to pixel color in image
    public GameObject prefab; 
    public Vector3 localScaleOfThisObject = new Vector3(1f,1f,1f);
    public int offsetX;
    public int offsetZ;
    public int scaleOffset;
}