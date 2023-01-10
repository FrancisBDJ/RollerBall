using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    private GameManager _gameManager;
    public float rotationSpeed = 25f;
      
       
    public AudioClip collectHealthSound;
    public AudioClip errorSound;
    public GameObject collectHealthEffect;
       
       
       
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
       
    public void Cure()
    {
        Vector3 position = transform.position;
        if (_gameManager.health < 100)
        {
            
            AudioSource.PlayClipAtPoint(collectHealthSound, position);
            Instantiate(collectHealthEffect, position, Quaternion.identity);
            _gameManager.AddHealth();
            Destroy(gameObject);
        }
        else
        {
            AudioSource.PlayClipAtPoint(errorSound, position);
        }
    }
       
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cure();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
    }
}
