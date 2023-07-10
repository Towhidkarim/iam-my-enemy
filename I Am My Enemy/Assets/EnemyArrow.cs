using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public GameObject hitEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MainPlayerScript mainPlayer = collision.gameObject.GetComponent<MainPlayerScript>();
            mainPlayer.stats.TakeDamage(3);

            
            
        }
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
