using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Sphere : MonoBehaviour
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
    public Slider changeGauge;
    public float Gauge;

    bool changeBig;
    public GameObject[] block2;
    PlayerItem playerItem;
    float keyTimelimit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        GetItem = false;
        changeGauge.value = 1000;
        changeBig = true;
        block2 = GameObject.FindGameObjectsWithTag("block2");
        playerItem = GetComponent<PlayerItem>();
        keyTimelimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.Z) ||
            Input.GetKey("joystick button 0"))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if(playerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if(keyTimelimit > 0.5f)
                {
                    playerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if(normal.transform.localScale.x <= 2.6f && changeBig)
            {
                normal.transform.localScale = normal.transform.localScale + addcutSize;
                over.transform.localScale = over.transform.localScale + addcutSize;
                //changeGauge.value -= 0.01f;
            }
            //}
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if (normal.transform.localScale.x <= 2.6f)
            {
                normal.transform.localScale = normal.transform.localScale + downaddcutSize;
                over.transform.localScale = over.transform.localScale + downaddcutSize;
                //changeGauge.value -= 0.1f;
            }
            //}
        }
        if (Input.GetKey(KeyCode.X) ||
           Input.GetKey("joystick button 1"))
        {
            //changeSize = false;
            if (playerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if (keyTimelimit > 0.5f)
                {
                    playerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - addcutSize;
                over.transform.localScale = over.transform.localScale - addcutSize;
                //changeGauge.value += 0.01f;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //changeSize = false;
            if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - downaddcutSize;
                over.transform.localScale = over.transform.localScale - downaddcutSize;
                //changeGauge.value += 0.1f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z) ||
            Input.GetKeyUp("joystick button 0")||
            Input.GetKeyUp(KeyCode.X) ||
            Input.GetKeyUp("joystick button 1"))
        {
            keyTimelimit = 0;
        }

        //ゲージで大きさの指標をしている処理
        Gauge = normal.transform.localScale.x - 1.0f;
        changeGauge.value = (Gauge * 1000) / 1.6f;

        //if(changeSize)
        //{
        //    changeGauge.value -= normal.transform.localScale.x + 0.01f;
        //}
        //if (!changeSize)
        //{
        //    changeGauge.value += normal.transform.localScale.x + 0.01f;
        //}

        //if (changeGauge.value == 0)
        //{
        //    normal.transform.localScale = new Vector3(1, 1, 1);
        //    over.transform.localScale = new Vector3(1.1f, 1.1f, 1);
        //    changeSize = false;
        //}

        if (normal.transform.localScale.x == 1.0f)
        {
            changeSize = false;
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
        if (other.tag == "block2")
        {
            changeBig = false;
        }
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
            SceneManager.LoadScene("GameScene2");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        foreach (GameObject go in block2)
        {
            if (other.gameObject == go)
            {
                //Debug.Log("当たったよ");
                changeBig = false;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        foreach (GameObject go in block2)
        {
            if (other.gameObject == go)
            {
                //Debug.Log("当たってないよ");
                changeBig = true;
            }
        }
    }
}
