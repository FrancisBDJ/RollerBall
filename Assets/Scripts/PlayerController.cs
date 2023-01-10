using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 2;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int jumpForce = 8;
    private bool _isGrounded = true;
    [SerializeField] private Rigidbody playerRb;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }

    }

    private void PlayerMovent()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }


        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move forward and backward

        Vector3 movement = new Vector3(0f,0f , (verticalInput * moveSpeed * Time.deltaTime));
       transform.Translate(movement);
        
        
        //Player Rotation
        transform.Rotate(0f, horizontalInput * rotationSpeed, 0f);
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovent();
    }
}