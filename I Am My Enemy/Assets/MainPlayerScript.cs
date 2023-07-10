using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPlayerScript : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody2D rBody;
    Vector2 moveDir;
    public Camera cam;
    Vector2 mouseDir;
    Vector2 mousePos;
    private Animator ani;
    private SpriteRenderer sprite;
    public GameObject infestParticle;
    public Image healthBar;
    public TextMeshProUGUI healthLabel;
    public Image deathScreen;
    public TextMeshProUGUI tutorialLabel;
    public Image shiftDuration;


    [NonSerialized]
    public bool isInfested = false;
    [NonSerialized]
    public bool slowmo = false;
    [NonSerialized]
    public string currentWeapon = "Unarmed";
    [NonSerialized]
    public float shapeShiftTime = 0f; 

    GameManagerScript gms;
    public Texture2D attackCursor;

    public PlayerStats stats = new PlayerStats(20f, 10f);

    void Start()
    {
        ani = GetComponent<Animator>();
        sprite = ani.GetComponent<SpriteRenderer>();
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        stats.healthBar = healthBar;
        stats.healthLabel = healthLabel;
        stats.healthLabel.text = (stats.maxHealth + "/" + stats.maxHealth).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(shapeShiftTime <= 0)
        {
            isInfested = false;
            transform.Find("WeaponPoint").Find(currentWeapon).gameObject.SetActive(false);
            transform.Find("WeaponPoint").Find("Unarmed").gameObject.SetActive(false);
            currentWeapon = "Unarmed";
        }
        else if(shapeShiftTime > 0 && isInfested)
        {
            shapeShiftTime -= Time.deltaTime;
        }

        shiftDuration.fillAmount = (float) (shapeShiftTime / 10f);

        if(stats.currentHealth <= 0)
        {
            DeathAction();
        }
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(!isInfested)
        {
            tutorialLabel.text = "Hold Right Mouse Button on an enemy to shape shift";
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            tutorialLabel.text = " ";
        }
            

        if(Input.GetMouseButtonDown(1) )
        {
            Time.timeScale = 0.15f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            slowmo = true;
            


        }
        if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            slowmo = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            if (gms.enemies.Count > 0)
            { 
                int randomIndex = UnityEngine.Random.Range(0, gms.enemies.Count - 1);
                //transform.position = gms.enemies[randomIndex].transform.position;
                if(GetEnemyOnMouse() != null)
                {

                    GameObject targetEnemy = GetEnemyOnMouse();
                    transform.position = targetEnemy.transform.position;

                    GetComponent<SpriteRenderer>().sprite = GetEnemyOnMouse().GetComponent<SpriteRenderer>().sprite;
                    GetComponent<SpriteRenderer>().color = GetEnemyOnMouse().GetComponent<SpriteRenderer>().color;

                    string weaponName = targetEnemy.GetComponent<StatManager>().stats.weaponName;

                    transform.Find("WeaponPoint").Find(currentWeapon).gameObject.SetActive(false);
                    currentWeapon = weaponName;
                    transform.Find("WeaponPoint").Find(weaponName).gameObject.SetActive(true);
                    isInfested = true;
                    shapeShiftTime = 10f;
                    targetEnemy.GetComponent<StatManager>().Kill();

                }


            }
        }

        

        if(moveDir.x > 0f)
        {
            ani.SetBool("isWalking", true);
            sprite.flipX = false;
        }
        else if (moveDir.x < 0f)
        {
            ani.SetBool("isWalking", true);
            sprite.flipX = true;
        }
        else if(moveDir.y > 0f || moveDir.y < 0f)
        {
            ani.SetBool("isWalking", true);      
        }
        else
        {
            ani.SetBool("isWalking", false);
        }

    }

    private void FixedUpdate()
    {   
        rBody.MovePosition(rBody.position + moveDir * stats.speed * Time.fixedDeltaTime);

        if (GetEnemyOnMouse() != null && slowmo)
            Cursor.SetCursor(attackCursor, new Vector2(attackCursor.height / 2, attackCursor.width / 2), CursorMode.Auto);
        else if(slowmo) Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    GameObject GetEnemyOnMouse()
    {
        Collider2D detectedCollider = Physics2D.OverlapBox(mousePos, Vector2.one, 0f);
        if (detectedCollider == null) return null; 
        else if (detectedCollider.gameObject.tag == "Enemey")
        {

            return detectedCollider.gameObject;
        }
        else return null;
    }

    void EndInfest()
    {
        isInfested = false;
        transform.Find("WeaponPoint").Find("Unarmed").gameObject.SetActive(true);
        transform.Find("WeaponPoint").Find(currentWeapon).gameObject.SetActive(false);


    }

    public void DeathAction()
    {
        Time.timeScale = 0f;
        deathScreen.gameObject.SetActive(true);
    }

}
