using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PerkManager : MonoBehaviour
{

    public PlayerPerk[] perks;
    public GameObject perkChoosingUi;
    public MainPlayerScript playerScript;
    public EnemySpawner enemySpawner;
    public PerkInDisplay[] persInDisplay;
    float timer = 2f;
    int[] perIndexes = new int[3];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
           // ActivateUi();

            timer = 1f;

        }
        else timer -= Time.deltaTime;
        //persInDisplay[1].description.text = "Hello 1";
        //persInDisplay[2].description.text = "Hello 2";

    }

    public void ActivateUi()
    {
        Time.timeScale = 0f;
        perkChoosingUi.SetActive(true);
        for(int i = 0; i < 3; i++)
        {
            int random = UnityEngine.Random.Range(0, perks.Length - 1);
            perIndexes[i] = random;
            string title = perks[random].perkName;
            string desc = perks[random].description;
            persInDisplay[i].title.text = title;
            persInDisplay[i].description.text = desc;
        }
    }

    public void DeactivateUi()
    {
        perkChoosingUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OptionOne()
    {
        CommitPerk(0);
        DeactivateUi();
    }
    public void OptionTwo()
    {   
        CommitPerk(1);
        DeactivateUi();
    }
    public void OptionThree()
    {
        CommitPerk(2);
        DeactivateUi();

    }

    public void CommitPerk(int index)
    {
        PlayerPerk toBeApplied = perks[perIndexes[index]];
        playerScript.stats.AddDamagePct(toBeApplied.damageMulti);
        playerScript.stats.AddHealthPct(toBeApplied.healthIncPct);
        playerScript.stats.AddDamageReductionPct(toBeApplied.damageReductionPctInc);
        playerScript.stats.AddProjectile(toBeApplied.projectileInc);
        playerScript.stats.AddChanceToHeal(toBeApplied.chanceToHeal);
    }
}
