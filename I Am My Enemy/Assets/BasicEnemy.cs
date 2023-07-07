using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Rigidbody2D rb;
    public float speed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            Vector2 direction = ((Vector2)target.position - rb.position);
            direction.Normalize();
            float rotation = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotation * 200f;
            rb.velocity = transform.up * speed;
        }
    }
}
