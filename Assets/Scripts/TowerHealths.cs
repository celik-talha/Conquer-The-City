using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerHealths : MonoBehaviour
{
    public Material matPlayer;
    public Material matFree;
    public Material matEnemy;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;
    [SerializeField] GameObject f1;
    [SerializeField] GameObject f2;
    [SerializeField] GameObject f3;
    [SerializeField] GameObject e1;
    [SerializeField] GameObject e2;
    [SerializeField] GameObject e3;

    int p1Health = 10;
    int p2Health = 10;
    int p3Health = 10;
    int f1Health = 0;
    int f2Health = 0;
    int f3Health = 0;
    int e1Health = -10;
    int e2Health = -10;
    int e3Health = -10;

    public GameObject p1TM;
    public GameObject p2TM;
    public GameObject p3TM;
    public GameObject f1TM;
    public GameObject f2TM;
    public GameObject f3TM;
    public GameObject e1TM;
    public GameObject e2TM;
    public GameObject e3TM;


    TextMeshPro p1Text;
    TextMeshPro p2Text;
    TextMeshPro p3Text;
    TextMeshPro f1Text;
    TextMeshPro f2Text;
    TextMeshPro f3Text;
    TextMeshPro e1Text;
    TextMeshPro e2Text;
    TextMeshPro e3Text;

    //Tower Owners 1=Player 2=Enemy 3=Free
    int p1Owner = 1;
    int p2Owner = 1;
    int p3Owner = 1;
    int f1Owner = 3;
    int f2Owner = 3;
    int f3Owner = 3;
    int e1Owner = 2;
    int e2Owner = 2;
    int e3Owner = 2;


    GameObject currentFrom;
    GameObject currentTo;
    int process = 0;

    void Start()
    {
        p1Text = p1TM.GetComponent<TextMeshPro>();
        p2Text = p2TM.GetComponent<TextMeshPro>();
        p3Text = p3TM.GetComponent<TextMeshPro>();
        f1Text = f1TM.GetComponent<TextMeshPro>();
        f2Text = f2TM.GetComponent<TextMeshPro>();
        f3Text = f3TM.GetComponent<TextMeshPro>();
        e1Text = e1TM.GetComponent<TextMeshPro>();
        e2Text = e2TM.GetComponent<TextMeshPro>();
        e3Text = e3TM.GetComponent<TextMeshPro>();
        setStats();
    }

    public void addBall(GameObject from, GameObject to, GameObject path)
    {

        if (from == p1)
        {
            if (p1Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == p2)
        {
            if (p2Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == p3)
        {
            if (p3Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == f1)
        {
            if (f1Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == f2)
        {
            if (f2Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == f3)
        {
            if (f3Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == e1)
        {
            if (e1Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == e2)
        {
            if (e2Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else if (from == e3)
        {
            if (e3Owner == 1)
            {
                process = 1;
            }
            else
            {
                process = -1;
            }
        }
        else
        {
            Debug.Log("TOWER HEALTH SCRIPT UNDEFINED FROM");
        }


        if (to == p1)
        {
            p1Health = p1Health + process;
            if (p1Health > 0)
            {
                setFriend(p1);
                p1Owner = 1;
            }
            else if (p1Health==0)
            {
                setFree(p1);
                p1Owner = 3;
            }
            else
            {
                setEnemy(p1);
                p1Owner = 2;
            }

        }
        else if (to == p2)
        {
            p2Health = p2Health + process;
            if (p2Health > 0)
            {
                setFriend(p2);
                p2Owner = 1;
            }
            else if (p2Health == 0)
            {
                setFree(p2);
                p2Owner = 3;
            }
            else
            {
                setEnemy(p2);
                p2Owner = 2;
            }
        }
        else if (to == p3)
        {
            p3Health = p3Health + process;
            if (p3Health > 0)
            {
                setFriend(p3);
                p3Owner = 1;
            }
            else if (p3Health == 0)
            {
                setFree(p3);
                p3Owner = 3;
            }
            else
            {
                setEnemy(p3);
                p3Owner = 2;
            }
        }
        else if (to == f1)
        {
            f1Health = f1Health + process;
            if (f1Health > 0)
            {
                setFriend(f1);
                f1Owner = 1;
            }
            else if (f1Health == 0)
            {
                setFree(f1);
                f1Owner = 3;
            }
            else
            {
                setEnemy(f1);
                f1Owner = 2;
            }
        }
        else if (to == f2)
        {
            f2Health = f2Health + process;
            if (f2Health > 0)
            {
                setFriend(f2);
                f2Owner = 1;
            }
            else if (f2Health == 0)
            {
                setFree(f2);
                f2Owner = 3;
            }
            else
            {
                setEnemy(f2);
                f2Owner = 2;
            }
        }
        else if (to == f3)
        {
            f3Health = f3Health + process;
            if (f3Health > 0)
            {
                setFriend(f3);
                f3Owner = 1;
            }
            else if (f3Health == 0)
            {
                setFree(f3);
                f3Owner = 3;
            }
            else
            {
                setEnemy(f3);
                f3Owner = 2;
            }
        }
        else if (to == e1)
        {
            e1Health = e1Health + process;
            if (e1Health > 0)
            {
                setFriend(e1);
                e1Owner = 1;
            }
            else if (e1Health == 0)
            {
                setFree(e1);
                e1Owner = 3;
            }
            else
            {
                setEnemy(e1);
                e1Owner = 2;
            }
        }
        else if (to == e2)
        {
            e2Health = e2Health + process;
            if (e2Health > 0)
            {
                setFriend(e2);
                e2Owner = 1;
            }
            else if (e2Health == 0)
            {
                setFree(e2);
                e2Owner = 3;
            }
            else
            {
                setEnemy(e2);
                e2Owner = 2;
            }
        }
        else if (to == e3)
        {
            e3Health = e3Health + process;
            if (e3Health > 0)
            {
                setFriend(e3);
                e3Owner = 1;
            }
            else if (e3Health == 0)
            {
                setFree(e3);
                e3Owner = 3;
            }
            else
            {
                setEnemy(e3);
                e3Owner = 2;
            }
        }
        else
        {
            Debug.Log("TOWER HEALTH SCRIPT UNDEFINED TO");
        }
        setStats();


    }

    void setStats()
    {
        p1Text.text = Mathf.Abs(p1Health).ToString();
        p2Text.text = Mathf.Abs(p2Health).ToString();
        p3Text.text = Mathf.Abs(p3Health).ToString();
        f1Text.text = Mathf.Abs(f1Health).ToString();
        f2Text.text = Mathf.Abs(f2Health).ToString();
        f3Text.text = Mathf.Abs(f3Health).ToString();
        e1Text.text = Mathf.Abs(e1Health).ToString();
        e2Text.text = Mathf.Abs(e2Health).ToString();
        e3Text.text = Mathf.Abs(e3Health).ToString();
    }

    void setFriend(GameObject go)
    {
        go.GetComponent<MeshRenderer>().material = matPlayer;
    }
    void setEnemy(GameObject go)
    {
        go.GetComponent<MeshRenderer>().material = matEnemy;
    }
    void setFree(GameObject go)
    {
        go.GetComponent<MeshRenderer>().material = matFree;
    }

    public bool checkIdentity(GameObject go)
    {
        if (go==p1)
        {
            if (p1Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go==p2)
        {
            if (p2Health>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == p3)
        {
            if (p3Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == f1)
        {
            if (f1Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == f2)
        {
            if (f2Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == f3)
        {
            if (f3Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == e1)
        {
            if (e1Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == e2)
        {
            if (e2Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (go == e3)
        {
            if (e3Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
