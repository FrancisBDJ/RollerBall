using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{
       //private GameManager _gameManager;
       public float rotationSpeed = 20f;
      
       
       public AudioClip collectSound;
   
       public GameObject collectEffect;
       
       void Start()
       {
           //_gameManager = FindObjectOfType<GameManager>();
       }
       
       public void Collect()
       {
           if(collectSound)
               AudioSource.PlayClipAtPoint(collectSound, transform.position);
           if(collectEffect)
               Instantiate(collectEffect, transform.position, Quaternion.identity);
       }
       
       private void OnTriggerEnter(Collider collision)
       {
           if (collision.gameObject.CompareTag("Player"))
           {
              
               // Add points
               Collect();
               //_gameManager.AddPoints();
               Destroy(gameObject);
           }
       }
       // Update is called once per frame
       void Update()
       {
           transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
       }
}
