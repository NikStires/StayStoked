using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject zombie;
    public float timeBtwSpawns;
    private float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        if(nextSpawn < 0)
        {
            Instantiate(zombie, transform.position - new Vector3(-1, 0, 0), Quaternion.identity);
            nextSpawn += timeBtwSpawns;
        }
    }
}
