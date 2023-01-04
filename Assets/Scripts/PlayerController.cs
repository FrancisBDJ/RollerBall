using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 2;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int jumpForce = 8;
    private bool isGrounded = true;
    [SerializeField] 
    private Rigidbody _playerRb;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void PlayerMovent()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
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
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovent();
    }
}