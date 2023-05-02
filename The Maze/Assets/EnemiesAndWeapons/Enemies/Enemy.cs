using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    public string DescriptionForDeveloper;

    public float Health;

    public Sprite SpriteOfEnemy;
    public Weapon Weapon;

    public float Damage;

    public float Speed;
}
