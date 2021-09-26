using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    public Transform treeDrop;
    public int numToSpawn;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        int spawned = 0;

        while (spawned < numToSpawn)
        {
            position = new Vector3(Random.Range(100.0F, 1000F), 70, Random.Range(100.0F, 1000.0F));
            Instantiate(treeDrop, position, Quaternion.identity);
            spawned++;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
}
