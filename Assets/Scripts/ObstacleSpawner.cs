using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    
   
    private float _xMin = -15.0f;
    private float _xMax = 35.0f;
    private float _zMin = -42.0f;
    private float _zMax = 6.0f;
    private float _y = -0.45f;
    
    public void SpawnRandom()
    {

        float xPosition = Random.Range(_xMin, _xMax);
        float zPosition = Random.Range(_zMin, _zMax);
        Vector3 position = new Vector3(xPosition, _y, zPosition);
        Instantiate(obstaclePrefab, position, Quaternion.identity);
    }
    
    void Start()
    {
        var obstacles = Random.Range(4, 8);
        for(int i = 0; i < obstacles; i++)
        {
            SpawnRandom();
        }
    }
}
