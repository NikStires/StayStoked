using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    //AttackPos
    private float radius = 0.75f;
    private float angle;
    private Vector3 v3Pos;
    //Player
    private GameObject player;
    //Camera
    public Vector2 mousePos;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
        else
        {
            //Rotate FirePoint
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - player.GetComponent<Rigidbody2D>().position;
            float lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,lookAngle));
            //Move FirePoint With Mouse
            v3Pos = Input.mousePosition;
            v3Pos.z = player.transform.position.z - Camera.main.transform.position.z;
            v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
            v3Pos -= player.transform.position;
            angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
            if (angle < 0.0f)
            {
                angle += 360.0f;
            }
            float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            transform.position = new Vector3(player.transform.position.x + xPos, player.transform.position.y + yPos, 0f);
        }
    }
}
