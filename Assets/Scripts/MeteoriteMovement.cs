using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    // Cached reference
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Rigidbody _meteoriteRigidbody;

    
    private Vector3 _direction;

    [SerializeField] private float meteoriteSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _meteoriteRigidbody = GetComponent<Rigidbody>();
        _direction = _player.transform.position - transform.position;
        _meteoriteRigidbody.velocity = _direction * meteoriteSpeed;
        
        
    }
}
