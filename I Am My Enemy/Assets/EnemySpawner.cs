using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyType> enemyCollection;
    public TextMeshProUGUI announceLabel;
    public Image winScreen;

    GameManagerScript gms;
    MainPlayerScript mainPlayer;
    [NonSerialized]
    public int currentWave = 0;
    int enemyPerWave = 30;
    int enemyIncreasePerWave = 15;
    int spawnCount = 0;
    int spawnsThisWave;
    float spawnDelay = 2f;
    float waveDuration = 30f;

    float waveCountDown = 4.5f;
    void Start()
    {
        gms = GetComponent<GameManagerScript>();
        mainPlayer = gms.player.GetComponent<MainPlayerScript>();
        spawnsThisWave = enemyIncreasePerWave;
    }


    void Update()
    {
        if (waveCountDown > 0)
        {
            if (waveCountDown > 3)
            {
                if(currentWave == 0) announceLabel.text = "Starting!";
                else announceLabel.text = "Wave Complete!";
            } 
            else
            {
                announceLabel.text = "Starting Wave  " + (currentWave + 1) + " in " + Mathf.Floor(waveCountDown);


            }
            waveCountDown -= Time.deltaTime;
        }
        else if (waveDuration > 0)
        {
            waveDuration -= Time.deltaTime;
        }
        else if (waveDuration <= 0)
        {
            gms.player.GetComponent<PerkManager>().ActivateUi();
            StatIncrement();
            currentWave++;
            if (currentWave == 5) YouWin();
            waveDuration = 30f + 5f * currentWave;
            waveCountDown = 3f;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector2.zero, 100);
            foreach (Collider2D collider in colliders)
            {
                if(collider.gameObject.transform.CompareTag("Enemey"))
                {
                    collider.gameObject.GetComponent<BasicEnemy>().Kill();
                }
            }
        }
        if (spawnDelay <= 0 && waveCountDown <=0)
        {
            announceLabel.text = Mathf.Floor(waveDuration).ToString();
            int count = SpawnEnemy();
            spawnCount += count;
            spawnDelay = 1.5f;

        }

        else spawnDelay -= Time.deltaTime;

    }

    int SpawnEnemy()
    {
        int spawnCount = 1 + UnityEngine.Random.Range(0, (int)Mathf.Round(currentWave / 3f));

        float newLocx = UnityEngine.Random.Range(-47f, 47f);
        float newLocy = UnityEngine.Random.Range(-27f, 27f);
        Vector2 newLoc = new Vector2(newLocx, newLocy);




        for (int i = 1; i <= spawnCount; i++)
        {
            float chance = UnityEngine.Random.Range(0, 1f);
            int spawnTier = 0;
            if (chance > 0.7f) spawnTier = 1;
            else if (chance > 0.3f) spawnTier = 0;

            float spawnLocx = UnityEngine.Random.Range(-2f, 2f);
            float spawnLocy = UnityEngine.Random.Range(-2f, 2f);
            Vector2 spawnLoc = newLoc + new Vector2(spawnLocx, spawnLocy);
            gms.enemies.Add(Instantiate(enemyCollection[spawnTier].enemy, spawnLoc, Quaternion.identity));
        }

        return spawnCount;
    }

    public void StatIncrement()
    {
        mainPlayer.stats.AddHealthPct(0.05f);
        mainPlayer.stats.AddDamagePct(0.05f);
    }

    public void YouWin()
    {
        Time.timeScale = 0f;
        winScreen.gameObject.SetActive(true);
    }
}
