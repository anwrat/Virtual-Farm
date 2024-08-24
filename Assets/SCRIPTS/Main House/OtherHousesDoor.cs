using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class OtherHouses : MonoBehaviour
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
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("smolhousedoor").transform.position);
        var d2 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("Door_1.1x2.0_A1_R_a_Collider").transform.position);
        if (Input.GetKeyDown(KeyCode.E))//get e button from keyboard event 
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.name == "Door_1.1x2.0_A1_R_a_Collider" || hit.collider.gameObject.name == "smolhousedoor")
                {
                    if(d1<=3 || d2<=3)//check if player is close to door
                    {
                        float p = GameObject.Find("smolhousedoor").transform.rotation.y;
                        if (p == 0.0f)//this rotation value was checked in console through debug log
                        {
                            p = 1f;
                            GameObject.Find("smolhousedoor").transform.Rotate(0.0f, -100.0f, 0.0f, Space.Self);//change the rotation of gameobject
                        }
                        else
                        {
                            p = 0.0f;
                            GameObject.Find("smolhousedoor").transform.Rotate(0.0f, 100.0f, 0.0f, Space.Self);//reduce the changed rotation value back to default
                        }
                    }
                }
            }
        }
    }
}