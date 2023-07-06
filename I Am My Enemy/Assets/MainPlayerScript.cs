using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody2D rBody;
    Vector2 moveDir;
    public Camera cam;
    Vector2 mouseDir;
    Vector2 mousePos;
    private Animator ani;
    private SpriteRenderer sprite;

   

    void Start()
    {
        ani = GetComponent<Animator>();
        sprite = ani.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        mousePos = Input.mousePosition;
        Vector2 worldCoord = cam.ScreenToWorldPoint(mousePos);
        mouseDir = (worldCoord - (Vector2)transform.position).normalized;
        if(moveDir.x > 0f)
        {
            ani.SetBool("isWalking", true);
            sprite.flipX = false;

        }
        else if (moveDir.x < 0f)
        {
            ani.SetBool("isWalking", true);
            sprite.flipX = true;

        }
        else if(moveDir.y > 0f || moveDir.y < 0f)
        {
            ani.SetBool("isWalking", true);
            
        }
        else
        {
            ani.SetBool("isWalking", false);
        }

    }

    private void FixedUpdate()
    {   
        float dist = (mousePos - (Vector2)transform.position).sqrMagnitude;
        if (dist > 5000)
        {
            //rBody.MovePosition(rBody.position + mouseDir * movementSpeed * Time.fixedDeltaTime);
        }

        rBody.MovePosition(rBody.position + moveDir * movementSpeed * Time.fixedDeltaTime);
    }
}