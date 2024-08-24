using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FenceDoor : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Mouse mouse = Mouse.current;
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("FenceDoor1").transform.position);
        var d2 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("FenceDoor2").transform.position);
        var d3 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("FenceDoor3").transform.position);
        var d4 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("FenceDoor4").transform.position);
        if (Input.GetKeyDown(KeyCode.E))//get e button from keyboard event 
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //For FenceDoor1
                if (hit.collider.gameObject.name == "FenceDoor1" && d1<=3)
                {
                    float p = hit.collider.gameObject.transform.rotation.x;//assigning rotation value to a variable so that the interaction becomes quicker
                    if (p==0.6532815f)//this rotation value was checked in console through debug log
                    {
                        p = 1f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, 100.0f,Space.Self);//change the rotation of gameobject
                    }
                    else
                    {
                        p = 0.6532815f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, -100.0f, Space.Self);//reduce the changed rotation value back to default
                    }
                }
                //For FenceDoor2
                if (hit.collider.gameObject.name == "FenceDoor2" && d2<=3)
                {
                    float p = hit.collider.gameObject.transform.rotation.x;
                    if ( p== 0.6532815f)
                    {
                        p = 1f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, -100.0f, Space.Self);
                    }
                    else
                    {
                        p = 0.6532815f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, 100.0f, Space.Self);
                    }
                }
                //For FenceDoor3
                if (hit.collider.gameObject.name == "FenceDoor3" && d3<=3)
                {
                    float p = hit.collider.gameObject.transform.rotation.x;
                    if (p == 0.6408564f)
                    {
                        p = 1f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, 100.0f, Space.Self);
                    }
                    else
                    {
                        p = 0.6408564f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, -100.0f, Space.Self);
                    }
                }
                //For FenceDoor4
                if (hit.collider.gameObject.name == "FenceDoor4" && d4<=3)
                {
                    float p = hit.collider.gameObject.transform.rotation.x;
                    if ( p== 0.2988362f)
                    {
                        p =1f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, 100.0f, Space.Self);
                    }
                    else
                    {
                        p = 0.2988362f;
                        hit.collider.gameObject.transform.Rotate(0.0f, 0.0f, -100.0f, Space.Self);
                    }
                }
            }
        }
    }
}