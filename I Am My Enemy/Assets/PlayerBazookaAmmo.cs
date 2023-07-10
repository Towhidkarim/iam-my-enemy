using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBazookaAmmo : MonoBehaviour
{
    public GameObject destroyParticle;
    public float damage = 4f;
    [NonSerialized]
    public float damageMultifplier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] collidedObjects = Physics2D.OverlapCircleAll(transform.position, 3);
        foreach(Collider2D col in collidedObjects)
        {
            if (col.gameObject.CompareTag("Enemey"))
            {
                col.gameObject.GetComponent<StatManager>().stats.TakeDamage(damage);
                MainPlayerScript mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayerScript>();
                float random = UnityEngine.Random.Range(0, 1f);
                float chance = mainPlayer.stats.chanceToHeal;
                if (random <= chance)
                {
                    mainPlayer.stats.Heal(1);
                }
            }
        }
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
