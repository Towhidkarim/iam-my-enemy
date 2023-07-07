using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public Transform target;
    Rigidbody2D rb;
    public float speed = 30f;
    public GameObject particleHit;


    float delay = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Enemey").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)target.position - rb.position);
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotation * 960f;
        rb.velocity = transform.up * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particleHit, rb.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
