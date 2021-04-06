using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    GameObject Item;
    GameObject NormalPlayer;

    Vector2 MyScale;
    Vector2 MyPosition;
    Vector2 ItemdropPosition;

    bool GetItem = false;

    // Start is called before the first frame update
    void Start()
    {
        Item = GameObject.Find("Item");
        NormalPlayer = GameObject.Find("normalPlayer");
    }

    void Update()
    {
        MyPosition = NormalPlayer.transform.position;
        MyScale = NormalPlayer.transform.localScale;

        ItemdropPosition = new Vector2(MyPosition.x + 1.5f, MyPosition.y + 1);
        if (GetItem)
        {
            Item.transform.position = MyPosition;
            if(Input.GetKeyDown("e")|| Input.GetKeyDown("joystick button 5"))
            {
                Item.transform.position = ItemdropPosition;
                GetItem = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("当たった");
        if (other.tag == "Item")
        {
            Debug.Log("アイテムに当たった");
            if (MyScale.x / 1.3f >= Item.transform.localScale.x)
            {
                GetItem = true;
            }
        }
    }
}
