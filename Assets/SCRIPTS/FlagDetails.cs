using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlagDetails : MonoBehaviour
{
    GameObject fd1;
    GameObject fd2;
    GameObject fd3;
    GameObject fd4;
    // Start is called before the first frame update
    void Start()
    {
        fd1 = GameObject.Find("flagmouse1");
        fd2 = GameObject.Find("flagmouse2");
        fd3 = GameObject.Find("frontdetails");
        fd4 = GameObject.Find("backdetails");
        fd1.SetActive(false);
        fd2.SetActive(false);
        fd3.SetActive(false);
        fd4.SetActive(false);
    }
    //For events to be shown on mouseover
    void OnMouseOver()
    {
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("polest").transform.position);
        if (d1 <= 7)
        {
            fd1.SetActive(true);
            fd2.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        fd1.SetActive(false);
        fd2.SetActive(false);
    }
    //For Details to be shown after pressing E
    [SerializeField]
    private Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void FixedUpdate()
    {
        Mouse mouse = Mouse.current;
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("polest").transform.position);
        if (d1 <= 7)//check the distance of player from pole
        {
            if (Input.GetKeyDown(KeyCode.E))//take e input from player
            {
                Vector3 mousePosition = mouse.position.ReadValue();
                Ray ray = m_Camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))//using raycast
                {
                    if (hit.collider.gameObject.name == "polest")//if raycast collides with pole
                    {
                        //displaying the details
                        fd3.SetActive(true);
                        fd4.SetActive(true);
                    }
                }
            }
        }
        else
        {
            //hiding the details when player moves away
            fd3.SetActive(false);
            fd4.SetActive(false);
        }
    }

}
