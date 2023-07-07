using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay = 2f;
    float delay;
    void Start()
    {
        delay = spawnDelay;
    }

    void Update()
    {
        if(delay <= 0f)
        {
            delay = spawnDelay;
            Vector2 newPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Instantiate(enemy, newPos, Quaternion.identity);
        } 
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
