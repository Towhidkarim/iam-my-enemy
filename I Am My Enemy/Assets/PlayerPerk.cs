using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Perk", menuName ="Perk")]
public class PlayerPerk : ScriptableObject
{
    public string perkName;
    public string description;
    public float healthIncPct = 0f;
    public float damageMulti = 0f;
    public int projectileInc = 0;
    public float chanceToHeal = 0;
    public float damageReductionPctInc = 0f;
    
    
}
