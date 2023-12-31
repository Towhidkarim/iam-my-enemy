using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;
    Rigidbody2D rb;
    public float speed = 30f;
    public GameObject particleHit;
    public GameManagerScript gms;
    public float baseDamage = 2.5f;
    [NonSerialized]
    public float damageMultiplier = 1;


    float delay = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Enemey").transform;
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        //Debug.Log(gms);
        target = gms.GetClosestEnemy().transform;
        targetPos = target.position;
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)targetPos - rb.position);
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotation * 960f;
        rb.velocity = transform.up * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particleHit, rb.position, Quaternion.identity);
        if(collision.collider.tag == "Enemey")
        {
            collision.collider.gameObject.GetComponent<StatManager>().stats.TakeDamage(baseDamage * damageMultiplier);
        }
        Destroy(gameObject);

    }
}
