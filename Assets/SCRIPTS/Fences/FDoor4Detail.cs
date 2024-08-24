using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDoor4Detail : MonoBehaviour
{
    GameObject fdoor1;
    GameObject fdoor2;
    // Start is called before the first frame update
    void Start()
    {
        fdoor1 = GameObject.Find("fd4front");
        fdoor2 = GameObject.Find("fd4back");
        fdoor1.SetActive(false);
        fdoor2.SetActive(false);
    }

    void OnMouseOver()
    {
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("FenceDoor4").transform.position);
        if (d1 <= 3)
        {
            fdoor1.SetActive(true);
            fdoor2.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        fdoor1.SetActive(false);
        fdoor2.SetActive(false);
    }
}
