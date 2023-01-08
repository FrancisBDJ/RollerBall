using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt( player.transform.position, Vector3.up );

        transform.position += transform.forward * (speed * Time.deltaTime);
    }
}
