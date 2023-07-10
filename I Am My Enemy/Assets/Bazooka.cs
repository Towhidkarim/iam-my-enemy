using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public GameObject ammo;
    float fireRate = 0.75f;
    float fireDelay = 0.75f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (fireDelay <= 0)
            {
                GameObject newBullet = Instantiate(ammo, transform.position, transform.rotation);
                //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 30f;
                FindAnyObjectByType<AudioManager>().Play("BazookaShoot", Random.Range(7f, 12f) * 0.1f);
                fireDelay = fireRate;
            }
            

        }

        if (fireDelay <= 0) fireDelay = 0;
        else fireDelay -= Time.deltaTime;
    }
}
