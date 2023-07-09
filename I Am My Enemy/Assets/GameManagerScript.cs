using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay = 2f;
    float delay;
    public List<GameObject> enemies;
    private GameObject player;
    void Start()
    {
        delay = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        FindAnyObjectByType<AudioManager>().Play("BGM", 1);
    }

    void Update()
    {
        if (delay <= 0f)
        {
            delay = spawnDelay;
            //SpawnEnemy();


        }
        else
        {
            delay -= Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        Vector2 newPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        enemies.Add(Instantiate(enemy, newPos, Quaternion.identity));


    }
    public GameObject GetClosestEnemy()
    {
        float mindist = Mathf.Infinity;
        GameObject closest = enemies[0];
        foreach(GameObject enemey in enemies) 
        {
            Vector2 distance = (enemey.transform.position - player.transform.position);
            if (distance.sqrMagnitude < mindist)
            {
                mindist = distance.sqrMagnitude;
                closest = enemey;
            }
        }

        return closest;
    }
}
