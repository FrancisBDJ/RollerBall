using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel2 : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.InitLevel2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
