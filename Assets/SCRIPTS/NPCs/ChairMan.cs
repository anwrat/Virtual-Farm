using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ChairMan : MonoBehaviour
{
    GameObject player;
    GameObject dialogue;
    [SerializeField]
    private Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
        dialogue = GameObject.Find("Dialogueman2");
        dialogue.SetActive(false);
    }
    void OnMouseOver()
    {

    }
    void OnMouseExit()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //function to remove gameobject after few seconds
        IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
        Mouse mouse = Mouse.current;
        var d1 = Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, GameObject.Find("Man2").transform.position);
        if (Input.GetKeyDown(KeyCode.E))//get e button from keyboard event 
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.name == "Man2")
                {
                    if (d1 <= 3)
                    {
                        dialogue.SetActive(true);
                        StartCoroutine(RemoveAfterSeconds(3, dialogue));//using Coroutine and IENumerator to make text disappear after some time
                    }
                }
            }
        }
    }
}