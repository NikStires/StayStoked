using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public Animator animator;
    Rigidbody2D rb2d;
    public float speed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        //Move Character
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));
    }
}
