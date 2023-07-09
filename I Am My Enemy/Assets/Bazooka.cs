using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public GameObject ammo;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(ammo, transform.position, transform.rotation);
            //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 30f;
            FindAnyObjectByType<AudioManager>().Play("ArrowShoot", Random.Range(10, 20) * 0.1f);

        }
    }
}
