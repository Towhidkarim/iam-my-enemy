using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Companion : MonoBehaviour
{

    public GameObject projectile;
    float delay;
    public float fireRate = 2f;
    private GameManagerScript gms;
    private GameObject player;

    void Start()
    {
        delay = 1f/fireRate;
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        player = GameObject.Find("MainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0f)
        {
            if(gms.enemies.Count > 0)
            {
            Instantiate(projectile, transform.position, Quaternion.Euler(0 , 0, Random.Range(0, 360)));
            //Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            delay = 1f/fireRate;

            }

        }
        else
        {
            delay -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
 
    }


}
