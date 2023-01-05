using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            // Die. Resta una vida o game over.
            _gameManager.LoseLife();
        }
        else if (collision.gameObject.CompareTag("Meteorite"))
        {
            _gameManager.TakeDamage(30f);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameManager.TakeDamage(10f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _gameManager.TakeDamage(20f);
        }
        
    }
}
