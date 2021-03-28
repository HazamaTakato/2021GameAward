﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        GetItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
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
    }
}