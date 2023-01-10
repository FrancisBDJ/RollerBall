using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public GameObject player;
    [SerializeField] private ParticleSystem hitPlayerParticleSystem;

    private Collider _collider1;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            Instantiate(hitPlayerParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt( player.transform.position, Vector3.up );

        transform.position += transform.forward * (speed * Time.deltaTime);
    }
}
