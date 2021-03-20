using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uiScript : MonoBehaviour
{
    public int playerRotationalPos;
    [SerializeField] private TextMeshProUGUI rotationText;
    [SerializeField] private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        rotationText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        playerObj = this.gameObject.transform.parent.gameObject;
        
    }

    // Update is called once per frame
   void Update()
    {
        playerRotationalPos = playerObj.GetComponent<movementScript>().playerRotate;
        switch (playerRotationalPos)
        {
            case 0:
                rotationText.SetText("North");
                break;

            case 90: 
                rotationText.SetText("East");
                break;

            case 180: 
                rotationText.SetText("South");
                break;

            case 270:
                rotationText.SetText("West");
                break;

            default:
                break;
        }
    }
}
