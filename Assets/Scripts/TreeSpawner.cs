using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject tree;
    private Tree curTree;
    public float timeBtwSpawn;
    public float nextSpawn;
    public bool spawn;
    private bool timeSet;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tree, transform.position, Quaternion.identity, transform);
        curTree = GetComponentInChildren<Tree>();
        spawn = curTree.isDead;
    }

    // Update is called once per frame
    void Update()
    {
        spawn = curTree.isDead;
        if (spawn && !timeSet)
        {
            Debug.Log("No Tree");
            nextSpawn += timeBtwSpawn;
            timeSet = true;
        }
        if(timeSet)
        {
            nextSpawn -= Time.deltaTime;
            if (nextSpawn < 0 && spawn)
            {
                Instantiate(tree, transform.position, Quaternion.identity, transform);
                curTree = GetComponentInChildren<Tree>();
                timeSet = false;
            }
        }
    }
}
