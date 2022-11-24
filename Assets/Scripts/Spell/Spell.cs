using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell: ScriptableObject
{
    public GameObject prefab;
    public GameObject groundMark;
    public float castDuration;
    public string animationTrigger;
    public float damage;
    public SpellType spellType;
    public float duration;
    public float slowPercentage;
    public float slowDuration;
    public int manaCost;
    public string description;
}
