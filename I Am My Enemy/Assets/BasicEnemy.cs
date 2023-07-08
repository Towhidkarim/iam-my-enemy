using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Rigidbody2D rb;
    public float speed = 5f;
    public float health = 10f;
    private SpriteRenderer sprite;
    GameManagerScript gms;
    public EnemyStats stats = new EnemyStats(10f, 5f, 2f);


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            Kill();
        }
        float facingDir = (target.position - transform.position).x;
        if (facingDir < 0) sprite.flipX = true;
        else if (facingDir > 0) sprite.flipX = false;

    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            Vector2 direction = ((Vector2)target.position - rb.position);
            direction.Normalize();
            float rotation = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotation * 200f;
            //rb.velocity = transform.up * speed;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);


            //Vector2 repelForce = Vector2.zero;
            //foreach  (GameObject enemy in  gms.enemies) {
            //    Transform enemyTransform = enemy.transform;
            //    if(enemyTransform != null)
            //    {
            //        float dist = (enemyTransform.position - transform.position).sqrMagnitude;
            //        if(dist <= 16)
            //        {
            //            repelForce = (rb.position - (Vector2)transform.position).normalized;
            //        }
            //    }
            //    rb.MovePosition((Vector2)transform.position - repelForce * Time.fixedDeltaTime);
            //}
        }
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else health = 0f;
    }

    public void Kill()
    {
        gms.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Projectile")
            stats.TakeDamage(5f);
    }
}