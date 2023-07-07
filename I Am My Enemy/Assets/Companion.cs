using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Companion : MonoBehaviour
{

    public GameObject projectile;
    float delay;
    public float fireRate = 2f;

    void Start()
    {
        delay = 1f/fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0f)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0 , 0, Random.Range(0, 360)));
            //Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            delay = 1f/fireRate;
        }
        else
        {
            delay -= Time.deltaTime;
        }

    }


}
