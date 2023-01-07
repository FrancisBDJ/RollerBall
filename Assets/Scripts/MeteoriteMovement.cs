using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MeteoriteMovement : MonoBehaviour
{
    // Cached reference
    [FormerlySerializedAs("_player")] [SerializeField]
    private GameObject player;
    [FormerlySerializedAs("_meteoriteRigidbody")] [SerializeField]
    private Rigidbody meteoriteRigidbody;

    
    private Vector3 _direction;

    [SerializeField] private float meteoriteSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        meteoriteRigidbody = GetComponent<Rigidbody>();
        _direction = player.transform.position - transform.position;
        meteoriteRigidbody.velocity = _direction * meteoriteSpeed;
        
        
    }
}
