using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int attackDamage;
    public int maxHP;
    private int curHP;
    private bool isDead;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && !isDead)
        {
            Debug.Log("Player Hit");
            other.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        animator.Play("Zombie_TakeDamage");
        if (curHP <= 0)
        {
            isDead = true;
            GetComponent<Collider2D>().enabled = false;
            animator.Play("Zombie_Dead");
            Destroy(gameObject, 0.9f);
        }
    }
}
