using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    public GameObject Item;
    bool GetItem = false;
    public GameObject over;
    public GameObject normal;
    Vector3 addcutSize;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.1f, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Z)||
            Input.GetKeyDown("joystick button 0"))
        {
            normal.transform.localScale = normal.transform.localScale + addcutSize;
            over.transform.localScale = over.transform.localScale + addcutSize;
        }
        if(Input.GetKeyDown(KeyCode.X)&&!GetItem||
           Input.GetKeyDown("joystick button 1")&& !GetItem)
        {
            if (normal.transform.localScale.x >= 1.1)
            {
                normal.transform.localScale = normal.transform.localScale - addcutSize;
                over.transform.localScale = over.transform.localScale - addcutSize;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown("joystick button 7"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(GetItem)
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GetItem = true;
            Destroy(Item);
            //SceneManager.LoadScene("EndingScene");
        }
        if(other.tag=="DeadItem"&&!GetItem)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(other.tag=="Goal"&&GetItem)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
