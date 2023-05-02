using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInit : MonoBehaviour
{
    public Enemy Enemy;
    public Weapon Weapon;

    private SpriteRenderer sR;
    private SpriteRenderer WEAPON_sR;
    private Rigidbody2D rb2d;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        WEAPON_sR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        sR.sprite = Enemy.SpriteOfEnemy;
        WEAPON_sR.sprite = Weapon.SpriteOfWeapon;
    }

    // Update is called once per frame
    void Update() { }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Obróć wektor prędkości gracza o 180 stopni wokół osi Z (czyli w kierunku wskazówek zegara)
            Vector2 reflectedDirection = Vector2.Reflect(
                other.gameObject.GetComponent<Rigidbody2D>().velocity,
                transform.position - other.transform.position
            );
            // Ustaw wektor prędkości gracza na wektor odbity
            other.gameObject.GetComponent<Rigidbody2D>().velocity = reflectedDirection;

            other.gameObject
                .GetComponent<PlayerHealth>()
                .UpdateHealth((Enemy.Damage + Weapon.Damage) * -1);
        }
    }
}
