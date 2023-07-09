using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(arrow, transform.position, transform.rotation);
            //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
            newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 50f;
            FindAnyObjectByType<AudioManager>().Play("ArrowShoot", Random.Range(10, 20) * 0.1f);

        }
    }
}
