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
            if (from==to)
            {
                Debug.Log("delete");
            }
            if (from == null || to == null)
            {
                Debug.Log("Delete");
            }
        }

        if (Input.touchCount==0 && isConnected==false)
        {
            touchScript.deletePath(this.transform);
        }
    }


    public void checkBug()
    {
        if (to==from)
        {
            touchScript.deletePath(this.transform);
        }
    }
}
