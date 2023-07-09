using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SquareEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Rigidbody2D rb;
    public float speed = 3.5f;
    public float health = 15f;
    private SpriteRenderer sprite;
    GameManagerScript gms;
    StatManager statManager;
    public GameObject deathParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        sprite = GetComponent<SpriteRenderer>();
        statManager = GetComponent<StatManager>();
        statManager.stats.enemeyName = "SquareEnemy";
        statManager.stats.weaponName = "Buzooka";
    }

    // Update is called once per frame
    void Update()
    {

        if (statManager.stats.health <= 0)
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
            Vector2 direction = ((Vector2)target.position - (Vector2) transform.position).normalized;

            //loat rotation = Mathf.Atan2(direction.y, direction.x);
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            //rb.velocity = transform.up * speed;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        }
    }

    public void Kill()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        gms.enemies.Remove(gameObject);
        Destroy(gameObject);
    }




}
