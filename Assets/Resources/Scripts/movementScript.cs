using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    Vector3 pos;
    public float speed;
    public int playerRotate;
    public bool canMove;

    public GameObject currentTile;

    void Start() 
    {
        pos = transform.position;

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerRotate = (int) transform.rotation.eulerAngles.y;

        if(Input.GetButtonDown("RotateRight") && transform.position == pos)
        {
            transform.Rotate(0, 90, 0);
        }

        else if(Input.GetButtonDown("RotateLeft") && transform.position == pos)
        {
            transform.Rotate(0, -90, 0);
        }

        else if (Input.GetButtonDown("MoveForward") && transform.position == pos && canMove)
        {
            pos += transform.forward;
        }

        if(currentTile.GetComponent<tileScript>().canMoveEast && playerRotate == 90)
        {
            canMove = true;
        }

        else if (currentTile.gameObject.GetComponent<tileScript>().canMoveNorth && playerRotate == 0)
        {
            canMove = true;
        }

        else if (currentTile.gameObject.GetComponent<tileScript>().canMoveSouth && playerRotate == 180)
        {
            canMove = true;
        }

        else if (currentTile.gameObject.GetComponent<tileScript>().canMoveWest && playerRotate == 270)
        {
            canMove = true;
        }

        else
        {
            canMove = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Tile")
        {
            Debug.Log("on top of tile");
            currentTile = (GameObject)other.gameObject;
        }  
    }  
}


