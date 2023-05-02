using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string Name;
    public string DescriptionForDeveloper;

    public bool IsRanged;
    public float Damage;

    public Sprite SpriteOfWeapon;

    [Header("Ranged Weapon Settings - IF IT IS RANGED")]
    public GameObject Projectile;
    public float ProjectileSpeed;

    // [Header("Melee Weapon Settings - IF IT IS MELEE")]
    // public float AttackSpeed;
    // public float AttackRange;
}
