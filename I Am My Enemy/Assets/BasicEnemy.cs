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
    StatManager statManager;
    public GameObject deathParticle;
    public string weaponName;
    public string enemyName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        sprite = GetComponent<SpriteRenderer>();
        statManager = GetComponent<StatManager>();
        statManager.stats.enemeyName = enemyName;
        statManager.stats.weaponName = weaponName;
    }

    // Update is called once per frame
    void Update()
    {

        if(statManager.stats.health <= 0)
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

            Quaternion angleRotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, angleRotation.z, angleRotation.w);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);


        }
    }

    public void Kill()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        gms.enemies.Remove(gameObject);
        FindAnyObjectByType<AudioManager>().Play("Boop", Random.Range(15, 20) * 0.1f);
        gms.enemies.Remove(gameObject);
        Destroy(gameObject);
    }




}
