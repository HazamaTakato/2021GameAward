using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereStage2 : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    public GameObject Item;
    public bool GetItem;
    public GameObject over;
    public GameObject normal;
    Vector3 addcutSize;
    Vector3 downaddcutSize;
    public bool hitflag;
    public bool changeSize;
    public GameObject fallblock;
    public GameObject lever;
    public GameObject leverblock;
    public GameObject leverblock2;
    public GameObject valve;
    public GameObject valveblock;
    public GameObject valve2;
    public GameObject valveblock2;
    public GameObject valve3;
    public GameObject valveblock3;
    public bool getValve;
    public bool getValve2;
    public bool getValve3;
    public bool leverON;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        getValve = false;
        GetItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!getValve)
        {
            float x = Input.GetAxis("Horizontal") * speed;
            rb.AddForce(x, 0, 0);
        }
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.Z) ||
            Input.GetKey("joystick button 0"))
        {
            if (normal.transform.localScale.x <= 2.6f)
            {
                normal.transform.localScale = normal.transform.localScale + addcutSize;
                over.transform.localScale = over.transform.localScale + addcutSize;
            }
        }
        if (Input.GetKeyDown(KeyCode.C) && !changeSize)
        {
            if (normal.transform.localScale.x <= 2.6f)
            {
                normal.transform.localScale = normal.transform.localScale + downaddcutSize;
                over.transform.localScale = over.transform.localScale + downaddcutSize;
            }
        }
        if (Input.GetKey(KeyCode.X) ||
           Input.GetKey("joystick button 1"))
        {
            if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - addcutSize;
                over.transform.localScale = over.transform.localScale - addcutSize;
            }
        }
        if (Input.GetKeyDown(KeyCode.V) && !changeSize)
        {
            if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - downaddcutSize;
                over.transform.localScale = over.transform.localScale - downaddcutSize;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 7"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GetItem = true;
        }
        //if(GetItem)
        //{
        //    Item.SetActive(false);
        //}

        //if(Input.GetKeyDown(KeyCode.C)&&GetItem)
        //{
        //    GetItem = false;
        //    Item.SetActive(true);
        //    Item.transform.position = this.transform.position;
        //}
        //if (normal.transform.localScale.x <= 1)
        //{
        //    hitflag = true;
        //}
        //else
        //{
        //    hitflag = false;
        //    GetItem = false;
        //}
        if (getValve)
        {
            this.transform.position = valve.transform.position;
            if (Input.GetKey(KeyCode.D) && valve.transform.localPosition.y >= 0.7f)
            {
                valve.transform.Rotate(0, 0, 0.1f);
                valve.transform.localPosition -= new Vector3(0, 0.001f, 0);
                valveblock.transform.localPosition-=new Vector3(0, 0.001f, 0);
            }
            if (Input.GetKey(KeyCode.A)&&valve.transform.localPosition.y<=10.5f)
            {
                valve.transform.Rotate(0, 0, -0.1f);
                valve.transform.localPosition += new Vector3(0, 0.001f, 0);
                valveblock.transform.localPosition += new Vector3(0, 0.001f, 0);
            }
        }
        if(getValve2)
        {
            this.transform.position = valve2.transform.position;
            if (Input.GetKey(KeyCode.D) && valve2.transform.localPosition.y >= 0.7f)
            {
                valve2.transform.Rotate(0, 0, 0.1f);
                valve2.transform.localPosition -= new Vector3(0, 0.001f, 0);
                valveblock2.transform.localPosition -= new Vector3(0, 0.001f, 0);
            }
            if (Input.GetKey(KeyCode.A) && valve2.transform.localPosition.y <= 8.6f)
            {
                valve2.transform.Rotate(0, 0, -0.1f);
                valve2.transform.localPosition += new Vector3(0, 0.001f, 0);
                valveblock2.transform.localPosition += new Vector3(0, 0.001f, 0);
            }
        }
        if(getValve3)
        {
            this.transform.position = valve3.transform.position;
            if (leverON)
            {
                fallblock.transform.localPosition -= new Vector3(0, 0.002f, 0);
                if (Input.GetKey(KeyCode.D) && valve3.transform.localPosition.y >= 5.0f)
                {
                    valve3.transform.Rotate(0, 0, 0.1f);
                    valve3.transform.localPosition -= new Vector3(0, 0.001f, 0);
                    valveblock3.transform.localPosition -= new Vector3(0, 0.001f, 0);
                }
                if (Input.GetKey(KeyCode.A) && valve3.transform.localPosition.y <= 8.6f)
                {
                    valve3.transform.Rotate(0, 0, -0.1f);
                    valve3.transform.localPosition += new Vector3(0, 0.001f, 0);
                    valveblock3.transform.localPosition += new Vector3(0, 0.001f, 0);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            getValve = false;
            getValve2 = false;
            getValve3 = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Item"&&hitflag)
        //{
        //    GetItem = true;
        //}
        //if(other.tag=="DeadItem"&&!GetItem)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        if (other.tag == "Goal" && GetItem)
        {
            SceneManager.LoadScene("EndingScene");
        }
        if(other.tag=="lever")
        {
            leverblock.SetActive(false);
            leverblock2.SetActive(false);
            lever.transform.localRotation = new Quaternion(0,0,3.5f,1);
            leverON = true;
        }

        if (other.tag == "valve")
        {
            getValve = true;
        }
        if (other.tag == "valve2")
        {
            getValve2 = true;
        }
        if (other.tag == "valve3")
        {
            getValve3 = true;
        }
    }
}
