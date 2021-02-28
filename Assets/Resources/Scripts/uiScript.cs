using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{
    public int playerRotationalPos;
    [SerializeField] private Text rotationText;
    [SerializeField] private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        rotationText = this.gameObject.GetComponentInChildren<Text>();
        playerObj = GameObject.Find("playerObj");
        
    }

    // Update is called once per frame
   void Update()
    {
        playerRotationalPos = playerObj.GetComponent<movementScript>().playerRotate;
        switch (playerRotationalPos)
        {
            case 0:
                rotationText.text = "North";
                break;

            case 90: 
                rotationText.text = "East";
                break;

            case 180: 
                rotationText.text = "South";
                break;

            case 270:
                rotationText.text = "West";
                break;

            default:
                break;
        }
    }
}
