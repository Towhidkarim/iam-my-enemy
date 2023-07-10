using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public GameObject hitParticle;

    private void Awake()
    {
        hitParticle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(gameObject, 3f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject enemey = collision.collider.gameObject;
        if (enemey.tag == "Enemey")
        {
            enemey.GetComponent<StatManager>().stats.TakeDamage(5f);
            MainPlayerScript mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayerScript>();

            float random = Random.Range(0, 1f);
            float chance = mainPlayer.stats.chanceToHeal;
            if (random <= chance)
            {
                mainPlayer.stats.Heal(1);
            }

        }
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
    }


}
