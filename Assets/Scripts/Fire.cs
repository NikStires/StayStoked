using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private FireLight fireLight;
    public bool isLit;
    public float timeBtwShrink;
    private float nextShrink;
    public AudioSource fireCrackle;
    //Animation
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isLit = true;
        nextShrink = 2f;
        fireLight = GetComponentInChildren<FireLight>();
        fireCrackle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        nextShrink -= Time.deltaTime;
        if(nextShrink < 0)
        {
            ShrinkFire();
            nextShrink += timeBtwShrink;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            if(other.gameObject.GetComponent<Player>().fuelCount > 0)
            {
                GrowFire();
                other.gameObject.GetComponent<Player>().fuelCount--;
                other.gameObject.GetComponent<Player>().score += 200;
            }
        }
    }

    private void ShrinkFire()
    {
        fireLight.Shrink();
        if (!fireLight.isLit)
        {
            fireCrackle.Stop();
            animator.SetBool("IsLit", false);
            Destroy(fireLight,1f);
        }
    }

    private void GrowFire()
    {
        fireLight.Grow();
    }
}
