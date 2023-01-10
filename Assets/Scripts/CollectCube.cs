using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{
       private GameManager _gameManager;
       public float rotationSpeed = 25f;
      
       
       public AudioClip collectSound;
   
       public GameObject collectEffect;
       
       
       
       void Start()
       {
           _gameManager = FindObjectOfType<GameManager>();
       }
       
       public void Collect()
       {
           Vector3 position = transform.position;
           AudioSource.PlayClipAtPoint(collectSound, position);
           Instantiate(collectEffect, position, Quaternion.identity);
           _gameManager.AddCube();
           Destroy(gameObject);
           
       }
       
       private void OnTriggerEnter(Collider collision)
       {
           if (collision.gameObject.CompareTag("Player"))
           {
               Collect();
           }
       }
       // Update is called once per frame
       void Update()
       {
           transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
       }
}
