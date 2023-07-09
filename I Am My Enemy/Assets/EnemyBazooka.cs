using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyWeaponShoot : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate = 0.5f;
    float fireDelay;
    void Start()
    {
        fireDelay = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireDelay <= 0)
        {
           
            GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
            //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 15f;
            fireDelay = 1f/fireRate;
        }
        else
        {
            fireDelay -= Time.deltaTime;
        }
    }
}
