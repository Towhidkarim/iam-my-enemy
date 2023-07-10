using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;

    float fireInterval = 0.25f;
    float fireDelay = 0f;
    public GameObject player;
    MainPlayerScript playerScript;
    void Start()
    {
        playerScript = player.GetComponent<MainPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            if(fireDelay <= 0)
            {
                
                //int projectileCount = playerScript.stats.projectileCount;
                //if(projectileCount == 2)
                //{
                //    Vector3 pos1 = player.transform.position + new Vector3(0, 1, 0);
                //    GameObject newBullet2 = Instantiate(arrow, pos1, transform.rotation);
                //    newBullet2.GetComponent<Rigidbody2D>().velocity = transform.right * 50f;
                //    Debug.Log(pos1);

                //}
                //if( projectileCount == 3)
                //{
                //    Vector3 pos3 = player.transform.position - new Vector3(0, 2, 0);
                //    GameObject newBullet3 = Instantiate(arrow, pos3, transform.rotation);
                //    newBullet3.GetComponent<Rigidbody2D>().velocity = transform.right * 50f;
                //}

                
                GameObject newBullet = Instantiate(arrow, transform.position, transform.rotation);

                //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 30f, ForceMode2D.Impulse);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * 50f;
                FindAnyObjectByType<AudioManager>().Play("ArrowShoot", Random.Range(10, 20) * 0.1f);
                fireDelay = fireInterval;
            }

        }
        if(fireDelay > 0) fireDelay -= Time.deltaTime;
    }
}
