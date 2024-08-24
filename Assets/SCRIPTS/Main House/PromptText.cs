using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;

public class PromptText : MonoBehaviour
{
    GameObject smoldoor;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game set door instruction text display to false
        smoldoor = GameObject.Find("door1prompt");
        smoldoor.SetActive(false);
        player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        //Calculate Distance between player and object
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("Door_1.1x2.0_A1_R_a_Collider").transform.position);
        if (d1 <= 3 )
        {
            smoldoor.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        smoldoor.SetActive(false);
    }
}
