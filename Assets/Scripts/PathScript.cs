using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    public bool isConnected;

    TouchActions touchScript;

    private void Start()
    {
        touchScript= GameObject.FindGameObjectWithTag("Manager").GetComponent<TouchActions>();
    }

    private void Update()
    {
        if (isConnected)
        {
            //checkBug();
        }

        if (Input.touchCount==0 && isConnected==false)
        {
            cancelPath();
        }
        //Debug.Log();
    }


    private void OnTriggerStay(Collider other)
    {
        if (isConnected = true && other.gameObject.name != "Floor")
        {
            if (other.gameObject != from && other.gameObject != to)
            {
                //Debug.Log(other.name);
            }
        }
    }

    public void checkBug()
    {
        if (to==from)
        {
            Debug.Log("deletss");
            //cancelPath();
        }
        if (from == null || to == null)
        {
            Debug.Log("Delete");
            //cancelPath();
        }

    }

    void cancelPath()
    {
        touchScript.deletePath(this.transform);
    }
}
