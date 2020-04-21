using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //HP
    public int maxHP;
    public int curHP;
    public HealthBar healthBar;
    public float timeBtwHeal;
    private float nextHeal;
    public int score;
    public Text scoreText;
    //Items
    public bool hasItem;
    public GameObject heldItem;
    public int fuelCount;
    public Text fuelCountText;
    public AudioSource pickupStick;
    //Attack
    public int axeDamage;
    public Transform attackPosition;
    public float attackRadius;
    public int maxObjectsHit = 5;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;
    public bool isAttacking;
    public AudioSource attack;
    //Menus
    public Text deathScreenScore;
    public GameObject HUD;
    public GameObject deathScreen;
    public Button restart;
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        objectsHit = new Collider2D[maxObjectsHit];
        restart.onClick.AddListener(RestartGame);
        menu.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<FireLight>().isLit)
        {
            HUD.SetActive(false);
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Collider2D>().enabled = false;
            deathScreen.transform.GetChild(1).gameObject.SetActive(true);
            deathScreenScore.text = score.ToString();
            deathScreen.SetActive(true);
        }
        fuelCountText.text = fuelCount.ToString();
        scoreText.text = "Score: " + score.ToString();
        healthBar.SetHealth(maxHP, curHP);
        if(Input.GetButtonDown("Fire1") && hasItem)
        {
            if(heldItem.GetComponent<Item>().itemType == "Axe")
            {
                attack.Play();
                Attack();
            }
        }
        if(Input.GetKeyDown(KeyCode.Q) && hasItem)
        {
            heldItem.transform.position = transform.position;
            heldItem.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            heldItem.GetComponent<Collider2D>().enabled = true;
            hasItem = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Item") && Input.GetKeyDown(KeyCode.E))
        {
            if (!hasItem)
            {
                heldItem = other.gameObject;
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                other.gameObject.GetComponent<Collider2D>().enabled = false;
                hasItem = true;
            }
        }
        if(other.gameObject.CompareTag("HealZone") && other.gameObject.GetComponentInParent<Fire>().isLit)
        {
            nextHeal -= Time.deltaTime;
            if (nextHeal < 0)
            {
                if(curHP < maxHP)
                {
                    curHP++;
                }
                nextHeal += timeBtwHeal;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            fuelCount++;
            pickupStick.Play();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }

    private void Attack()
    {
        isAttacking = true;
        Physics2D.OverlapCircleNonAlloc(attackPosition.position, attackRadius, objectsHit, selectObjectsToHit);
        if (objectsHit.Length > 0)
        {
            foreach (Collider2D hit in objectsHit)
            {
                if(hit.gameObject.CompareTag("Tree"))
                {
                    hit.gameObject.GetComponent<Tree>().TakeDamage(axeDamage);
                }
                else if(hit.gameObject.CompareTag("Zombie"))
                {
                    score += 100;
                    hit.gameObject.GetComponent<Zombie>().TakeDamage(axeDamage);
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetComponent<Collider2D>().enabled = false;
            HUD.SetActive(false);
            deathScreen.transform.GetChild(0).gameObject.SetActive(true);
            deathScreenScore.text = score.ToString();
            deathScreen.SetActive(true);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
