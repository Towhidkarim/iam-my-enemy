using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerStats
{
    public float baseHealth;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public float damageMultiplier;
    public float healthMultiplier;
    public float damageReductionPct = 0f;
    public int projectileCount = 3;
    public float chanceToHeal = 0.1f;
    public Image healthBar;
    public TextMeshProUGUI healthLabel;

    public PlayerStats(float baseHealth, float speed)
    {
        this.baseHealth = baseHealth;
        this.currentHealth = baseHealth;
        this.maxHealth = baseHealth;
        this.speed = speed;
        this.damageMultiplier = 1f;
        this.healthMultiplier = 1f;
        
    }

    public void AddHealthPct(float percentage)
    {
        healthMultiplier += percentage;
        float healthPercent = currentHealth / maxHealth;
        maxHealth = baseHealth * healthMultiplier;
        currentHealth = healthPercent * maxHealth;

    }

    public void AddDamagePct(float percentage)
    {
        damageMultiplier += percentage;
        GeneralUpdate();
    }

    public void AddDamageReductionPct(float percentage)
    {
        damageReductionPct += percentage;
        GeneralUpdate();
    }
    public void AddProjectile(int count)
    {
        projectileCount += count;
        GeneralUpdate();
    }
    public void AddChanceToHeal(float chance)
    {
        chanceToHeal += chance;
        GeneralUpdate();
    }

    public void TakeDamage(float amount)
    {
        float tempValue = currentHealth - (amount * (1 - damageReductionPct));
        currentHealth = Mathf.Clamp(tempValue, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
        GeneralUpdate();
    }

    public void GeneralUpdate()
    {
        healthLabel.text = (Mathf.Round(currentHealth * 100f)/100f + "/" + maxHealth).ToString();

    }

    public void Heal(float amount)
    {
        float tempValue = currentHealth + amount;
        currentHealth = Mathf.Clamp(tempValue, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
        GeneralUpdate();
    }
}
