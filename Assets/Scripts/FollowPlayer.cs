using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public int speed = 50;
    public GameObject player;
    [SerializeField] private Rigidbody enemyRigidbody;
    private Vector3 _direction;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyRigidbody = this.GetComponent<Rigidbody>();
        transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt( player.transform.position, Vector3.up );
        _direction = player.transform.position - transform.position;
        enemyRigidbody.velocity = _direction * (speed * Time.deltaTime);
    }

    
}
