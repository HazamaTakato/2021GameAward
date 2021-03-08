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

        if(Input.GetKeyDown(KeyCode.Z)&&normalSize)
        {
            this.transform.localScale = new Vector3(2, 2, 2);
            normalSize = false;
        }
        if(Input.GetKeyDown(KeyCode.X)&&!normalSize)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            normalSize = true;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item"&&!normalSize)
        {
            GetItem = true;
            Destroy(Item);
            SceneManager.LoadScene("EndingScene");
        }
    }
}
