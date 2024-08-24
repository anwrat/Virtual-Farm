using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TavernDoor : MonoBehaviour
{
    GameObject tdoor1;
    GameObject tdoor2;
    [SerializeField]
    private Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game set door instruction text display to false
        tdoor1 = GameObject.Find("taverndoor1");
        tdoor2 = GameObject.Find("taverndoor2");
        tdoor1.SetActive(false);
        tdoor2.SetActive(false);
    }
    void OnMouseOver()//mouse over sth function
    {
        //Calculate Distance between player and object
        var d3 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("wall_wood_door.001").transform.position);
        if(d3 <= 3)
        {
            tdoor1.SetActive(true);
            tdoor2.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        //Hide instruction after mouse is away

        tdoor1.SetActive(false);
        tdoor2.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Mouse mouse = Mouse.current;
        var d3 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("wall_wood_door.001").transform.position);
        if (d3<=3)//opening the door only if player is close
        {
            if (Input.GetKeyDown(KeyCode.E))//get e button from keyboard event 
            {
                Vector3 mousePosition = mouse.position.ReadValue();
                Ray ray = m_Camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.name == "wall_wood_door.001")
                    {
                        float p = GameObject.Find("PivotDoor").transform.rotation.y;//making an gameobject in unity to change pivot of door
                                                                                    //Need to rotate Pivot to rotate the door
                        if (p == 0.3420201f)//this rotation value was checked in console through debug log
                        {
                            p = 1f;
                            GameObject.Find("PivotDoor").transform.Rotate(0.0f, 100.0f, 0.0f, Space.Self);//change the rotation of gameobject
                        }
                        else
                        {
                            p = 0.3420201f;
                            GameObject.Find("PivotDoor").transform.Rotate(0.0f, -100.0f, 0.0f, Space.Self);//reduce the changed rotation value back to default
                        }
                    }
                }
            }
        }
    }
}