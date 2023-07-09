using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    GameManagerScript gms;
    public EnemyStats stats = new EnemyStats(10f, 5f, 2f);
    void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
           // Kill();
        }
    }

    public void Kill()
    {
        gms.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Projectile") { }
    }
}
