using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBazookaAmmo : MonoBehaviour
{
    public GameObject destroyParticle;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(destroyParticle, transform.position, Quaternion.identity);
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MainPlayerScript>().stats.TakeDamage(3);
        }
        Destroy(gameObject);
    }
}
