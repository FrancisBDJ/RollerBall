using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel3 : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.InitLevel3();
    }
}
