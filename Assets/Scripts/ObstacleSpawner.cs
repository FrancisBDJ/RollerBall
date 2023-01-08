using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    
   
    private float xMin = -25.0f;
    private float xMax = 25.0f;
    private float zMin = -50.0f;
    private float zMax = -1.0f;
    private float y = -0.45f;
    
    public void SpawnRandom()
    {

        float xPosition = Random.Range(xMin, xMax);
        float zPosition = Random.Range(zMin, zMax);
        Vector3 position = new Vector3(xPosition, y, zPosition);
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
    
    void Update()
    {
       
    }
}
