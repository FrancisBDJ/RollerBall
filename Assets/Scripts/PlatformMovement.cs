using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _endingPosition;
    private int _platformSpeed = 4;
    private bool _switch = false;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = new Vector3(17.0f, -0.7f, -33.0f);
        _endingPosition = new Vector3(5.0f, -0.7f, -33.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position,  _initialPosition,
                _platformSpeed * Time.deltaTime);  
        }
        else if (_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endingPosition,
                _platformSpeed * Time.deltaTime);
        }

        if(transform.position == _initialPosition)
        {
            _switch = true;
        }
        else if(transform.position == _endingPosition)
        {
            _switch = false;
        }
        
    }
}
