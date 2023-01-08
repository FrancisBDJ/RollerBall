using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    // Cached references
    [SerializeField] private GameObject meteoritePrefab;

    private float _spawntimer = 0.0f;
    private float _meteoriteSpawnFrequency = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(meteoritePrefab, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        _spawntimer += Time.deltaTime;
        if (_spawntimer > _meteoriteSpawnFrequency)
        {
            Instantiate(meteoritePrefab, transform.position, Quaternion.identity);
            _spawntimer = 0f;
        }
    }
}
