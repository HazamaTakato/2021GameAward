using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject player;
    Vector3 PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = player.transform.position;
        PlayerPosition.z = -8.8f;

        transform.position = PlayerPosition;
    }
}
