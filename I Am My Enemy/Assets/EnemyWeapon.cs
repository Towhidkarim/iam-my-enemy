using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousepos;
    public GameObject arrow;
    public Transform weapon;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        if (Input.GetButtonDown("Fire1"))
        {
            //GameObject newBullet = Instantiate(arrow, weapon.position, transform.rotation);
            ////newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
            //newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 40f;
            //FindAnyObjectByType<AudioManager>().Play("ArrowShoot", Random.Range(10, 20) * 0.1f);

        }
    }

    private void FixedUpdate()
    {


    }
}
