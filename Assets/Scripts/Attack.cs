using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    private Player player;
    public Vector3 offset;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            offset = new Vector3(-1, 0, 0);
            rotation = new Vector3(0, 0, 90);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            offset = new Vector3(1, 0, 0);
            rotation = new Vector3(0, 0, 270);
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            offset = new Vector3(0, -1, 0);
            rotation = new Vector3(0, 0, 195);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            offset = new Vector3(0, 1, 0);
            rotation = new Vector3(0, 0, 15);
        }
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(rotation);
        if(player.isAttacking)
        {
            animator.Play("Player_attack");
            player.isAttacking = false;
        }
    }
}
