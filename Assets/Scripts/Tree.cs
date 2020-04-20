using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject stick;
    public Vector3 offset;
    public int maxHP;
    private int curHP;
    public bool isDead;
    public AudioSource treeHit;
    public AudioSource treeBreak;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        treeHit.Play();
        if(curHP <= 0)
        {
            Drop();
            isDead = true;
            treeBreak.Play();
            Destroy(gameObject,0.5f);
        }
    }
    public void Drop()
    {
        offset.x = Random.Range(-3, 3);
        offset.y = Random.Range(-3, 3);
        Instantiate(stick, transform.position, Quaternion.identity);
    }
}
