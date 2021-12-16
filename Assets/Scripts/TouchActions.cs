using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActions : MonoBehaviour
{
    public GameObject lastActive;
    bool isFocused = false;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;

    public GameObject p1s;
    public GameObject p2s;
    public GameObject p3s;
    public GameObject f1s;
    public GameObject f2s;
    public GameObject f3s;
    public GameObject e1s;
    public GameObject e2s;
    public GameObject e3s;

    GameObject focusedObject;

    LayerMask rayLayer;
    LayerMask pathLayer;

    public GameObject path1;
    Vector3 scale;
    float scaleMultiplier;
    float scalerX;
    float scalerZ;

    GameObject lastPath;

    Vector3 startPos;
    Vector3 touchDir;
    bool isConnected = false;
    public bool isConnecting = false;

    Vector3 poolPos;
    public GameObject pool;
    public GameObject paths;
    GameObject path;

    GameObject pathPrefab;

    bool isCreated = false;

    GameObject prevPath;
    int i;

    private void Start()
    {
        rayLayer= LayerMask.GetMask("LayerMask");
        pathLayer = LayerMask.GetMask("PathMask");
        poolPos = pool.transform.position;

        pathPrefab = Resources.Load<GameObject>("Path");

        i = 0;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase==TouchPhase.Began)
            {
                Touch touchA = Input.GetTouch(0);
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("Tower"))
                    {
                        focusObject(raycastHit.collider.gameObject);
                        createPath();
                    }
                    else
                    {
                        lastActive.SetActive(false);
                        isFocused = false;
                    }
                    //Debug.Log(raycastHit.transform.name);
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (isFocused && isCreated)
                {
                    Touch touchA = Input.GetTouch(0);
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit raycastHit;

                    if (Physics.Raycast(raycast, out raycastHit, Mathf.Infinity, rayLayer))
                    {
                        if (raycastHit.collider.CompareTag("Tower"))
                        {
                            updatePath(raycastHit.transform.position,true,raycastHit.transform.gameObject);
                            isConnected = true;
                            isConnecting = false;
                        }
                        else
                        {
                            updatePath(raycastHit.point,false,raycastHit.transform.gameObject);
                            isConnected = false;
                            isConnecting = true;
                        }
                        //Debug.Log(raycastHit.transform.name);
                    }

                }
                else
                {
                    Touch touchA = Input.GetTouch(0);
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit raycastHit;
                    //Debug.Log("a");
                    if (Physics.Raycast(raycast, out raycastHit, Mathf.Infinity, pathLayer))
                    {
                        deletePath(raycastHit.transform);
                        Debug.Log("b");
                    }

                }

            }

            if (Input.GetTouch(0).phase==TouchPhase.Ended)
            {
                if (!isConnected)
                {
                    if (lastPath!=null)
                    {
                        deletePath(lastPath.transform);
                    }
                }
                else
                {
                    if (path!=null)
                    {
                        path.GetComponent<PathScript>().checkBug();
                    }
                }

                if (lastPath!=null)
                {
                    path.GetComponent<PathScript>().checkCollide();
                }

            }


        }
        
    }

    void focusObject(GameObject go)
    {
        lastActive.SetActive(false);
        isFocused = true;

        if (go == p1)
        {
            p1s.SetActive(true);
            lastActive = p1s;
            focusedObject = p1;

        }
        else if (go == p2)
        {
            p2s.SetActive(true);
            lastActive = p2s;
            focusedObject = p2;
        }
        else if (go == p3)
        {
            p3s.SetActive(true);
            lastActive = p3s;
            focusedObject = p3;
        }
        else if (go == f1)
        {
            f1s.SetActive(true);
            lastActive = f1s;
            focusedObject = f1;
        }
        else if (go == f2)
        {
            f2s.SetActive(true);
            lastActive = f2s;
            focusedObject = f2;
        }
        else if (go == f3)
        {
            f3s.SetActive(true);
            lastActive = f3s;
            focusedObject = f3;
        }
        else if (go == e1)
        {
            e1s.SetActive(true);
            lastActive = e1s;
            focusedObject = e1;
        }
        else if (go == e2)
        {
            e2s.SetActive(true);
            lastActive = e2s;
            focusedObject = e2;

        }
        else if (go == e3)
        {
            e3s.SetActive(true);
            lastActive = e3s;
            focusedObject = e3;
        }

    }

    void createPath()
    {

        if (i > 0 && path != null)
        {
            prevPath = path;
            prevPath.GetComponent<PathScript>().checkBug();
        }
        

        path = Instantiate(pathPrefab);
        isCreated = true;
        i++;

    }

    void updatePath(Vector3 destPos, bool isTower,GameObject to)
    {

        destPos.y = 1.06f;
        touchDir = destPos - lastActive.transform.position;
        touchDir = touchDir.normalized;
        startPos = lastActive.transform.position;


        path.transform.position = (startPos + destPos) / 2;
        path.transform.LookAt(startPos);
        path.transform.rotation = Quaternion.Euler(90f, path.transform.eulerAngles.y, path.transform.eulerAngles.z);

        scale = path.transform.localScale;
        scalerZ = ((destPos.z - startPos.z) * (destPos.z - startPos.z));
        scalerX = ((destPos.x - startPos.x) * (destPos.x - startPos.x));
        scaleMultiplier = Mathf.Sqrt(scalerX + scalerZ);
        scale.y = scaleMultiplier / 2f;
        path.transform.localScale = scale;

        lastPath = path;
        if (isTower==true && to!=focusedObject && to!= null)
        {
            path.transform.SetParent(paths.transform);
            isConnected = true;
            isConnecting = false;
            path.GetComponent<PathScript>().isConnected = true;
            path.GetComponent<PathScript>().from = focusedObject;
            path.GetComponent<PathScript>().to = to;

            if (focusedObject == to && isConnected == true)
            {
                isCreated = false;
                Destroy(path);
            }
            
        }
        else
        {
            isConnecting = true;
            isConnected = false;
            path.GetComponent<PathScript>().isConnected = false;
        }
    }

    public void deletePath(Transform deleteTransform)
    {
        Destroy(deleteTransform.gameObject);
        isConnecting = false;
        isConnected = false;
        //Debug.Log("deleted");
    }
}
