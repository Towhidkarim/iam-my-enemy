using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousepos;
    public GameObject arrow;
    public Transform weapon;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousepos - transform.position;
        float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GameObject newBullet = Instantiate(arrow, weapon.position, transform.rotation);
        //    //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
        //    newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 50f;
        //    FindAnyObjectByType<AudioManager>().Play("ArrowShoot", Random.Range(10, 20) * 0.1f);
            
        //}
    }

    private void FixedUpdate()
    {
        

    }
}
