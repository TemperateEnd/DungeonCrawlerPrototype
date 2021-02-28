using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazeScript : MonoBehaviour
{
    public GameObject playerInstance;
    public Canvas playerUI;
    
    [Header("Start Co-ordinates")]
    public int startX;
    public int startZ;

    [Header("Maze Boundaries")]
    public int mazeHeight;
    public int mazeWidth;

    // Start is called before the first frame update
    void Start()
    {
        startX = Random.Range((mazeWidth-mazeWidth),(mazeWidth-1));
        startZ = Random.Range((mazeHeight-mazeHeight),(mazeHeight-1));

        playerInstance = Instantiate(Resources.Load<GameObject>("Prefabs/playerObj"), new Vector3(startX, 0.5f, startZ), Quaternion.identity);
    }
}
