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
        maxHealth += baseHealth * healthMultiplier;
        currentHealth = healthPercent * maxHealth;

    }

    public void AddDamagePct(float percentage)
    {
        damageMultiplier += percentage;
    }

    public void TakeDamage(float amount)
    {
        float tempValue = currentHealth - amount;
        currentHealth = Mathf.Clamp(tempValue, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
        healthLabel.text = (currentHealth + "/" + maxHealth).ToString();
    }
}
