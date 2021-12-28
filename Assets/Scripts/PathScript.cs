using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    public bool isConnected;

    TouchActions touchScript;

    bool letCheckCollide = false;

    bool letSend = false;
    float speed = 2f;
    bool waiting = false;

    TowerHealths towerScript;

    private void Start()
    {
        touchScript= GameObject.FindGameObjectWithTag("Manager").GetComponent<TouchActions>();
        towerScript = GameObject.FindGameObjectWithTag("TManager").GetComponent<TowerHealths>();
    }


    private void FixedUpdate()
    {
        if (isConnected)
        {
            //checkBug();
        }

        if (Input.touchCount==0 && isConnected==false)
        {
            //cancelPath();
            //Debug.Log("dlt4");
        }
        //Debug.Log();

        if (letSend)
        {
            StartCoroutine(startTimer());
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (letCheckCollide)
        {
            if (isConnected = true && other.gameObject.name != "Floor")
            {
                if (other.gameObject != from && other.gameObject != to)
                {
                    if (other.tag=="Tower")
                    {
                        Debug.Log(other.name);
                        cancelPath();
                        Debug.Log("dlt5");
                    }
                }
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
        letSend = true;
    }

    void cancelPath()
    {
        touchScript.deletePath(this.transform);
    }

    public void checkCollide()
    {
        Debug.Log("checking");
        letCheckCollide = true;

    }

    IEnumerator startTimer()
    {
        if (!waiting)
        {
            waiting = true;
            yield return new WaitForSeconds(speed);
            sendBall();
            waiting = false;
        }
    }

    void sendBall()
    {
        //Debug.Log("sending");
        towerScript.addBall(from, to, this.gameObject);
    }
}
