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
    GameManagerScript gms;
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
        spawnsThisWave = enemyIncreasePerWave;
    }


    void Update()
    {
        if (waveCountDown > 0)
        {   
            if(waveCountDown > 3) announceLabel.text = "Wave Complete!";
            else
            announceLabel.text = "Starting Wave  " + (currentWave + 1) + " in " + Mathf.Floor(waveCountDown);
            waveCountDown -= Time.deltaTime;
        }
        else if (waveDuration > 0)
        {
            waveDuration -= Time.deltaTime;
        }
        else if (waveDuration <= 0)
        {
            waveDuration = 30f;
            currentWave++;
            waveCountDown = 3f;
        }
        if (spawnDelay <= 0 && waveCountDown <=0)
        {
            announceLabel.text = Mathf.Floor(waveDuration).ToString();
            int count = SpawnEnemy();
            spawnCount += count;
            spawnDelay = 1f;

        }

        else spawnDelay -= Time.deltaTime;
    }

    int SpawnEnemy()
    {
        int spawnCount = 1 + UnityEngine.Random.Range(0, 1) + (int)Mathf.Floor(currentWave / 3f);

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
}
