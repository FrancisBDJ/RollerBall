using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int rotationSpeed = 100;
    [SerializeField]
    private int moveSpeed = 10;
    [SerializeField] 
    private int jumpForce = 4;
    private bool isGrounded = true;
    [SerializeField]
    private Rigidbody _playerRb;
    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    
    
    
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
        _playerRb.transform.Translate(0,0, (verticalInput * Time.deltaTime * moveSpeed));
        
        //Player Rotation
        float x =  0;
        float y =  horizontalInput  * rotationSpeed;
        //float z = verticalInput  * rotationSpeed;
        float z =  0;
        
        currentEulerAngles += new Vector3(x , y, z);
        
        currentRotation.eulerAngles = currentEulerAngles;
        
        _playerRb.transform.rotation = currentRotation;
    }
    
    private void Start()
    {
        _playerRb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerMovent();
    }
}
