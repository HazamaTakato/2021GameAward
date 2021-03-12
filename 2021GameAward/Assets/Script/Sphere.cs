using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    bool normalSize = true;
    public GameObject Item;
    bool GetItem = false;
    public GameObject normal;
    public GameObject big;
    public GameObject over;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Z)&&normalSize||
            Input.GetKeyDown("joystick button 0")&&normalSize)
        {
            normal.SetActive(false);
            big.SetActive(true);
            normalSize = false;
            over.transform.localScale = new Vector3(2.1f, 2.1f, 1);
            over.transform.localPosition = new Vector3(over.transform.localPosition.x - 0.5f, over.transform.localPosition.y, over.transform.localPosition.z);
            big.transform.localPosition = new Vector3(big.transform.localPosition.x - 0.5f, big.transform.localPosition.y, big.transform.localPosition.z);
        }
        if(Input.GetKeyDown(KeyCode.X)&&!normalSize&&!GetItem||
           Input.GetKeyDown("joystick button 1")&& !normalSize&&!GetItem)
        {
            normal.SetActive(true);
            big.SetActive(false);
            normalSize = true;
            over.transform.localScale = new Vector3(1.1f, 1.1f, 1);
            over.transform.localPosition = new Vector3(over.transform.localPosition.x + 0.5f, over.transform.localPosition.y, over.transform.localPosition.z);
            big.transform.localPosition = new Vector3(big.transform.localPosition.x + 0.5f, big.transform.localPosition.y, big.transform.localPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown("joystick button 7"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(GetItem)
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            normal.GetComponent<Renderer>().material.color = Color.yellow;
            big.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item"&&!normalSize)
        {
            GetItem = true;
            Destroy(Item);
            //SceneManager.LoadScene("EndingScene");
        }
        if(other.tag=="DeadItem"&&!GetItem&&!normalSize)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(other.tag=="Goal"&&GetItem)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
