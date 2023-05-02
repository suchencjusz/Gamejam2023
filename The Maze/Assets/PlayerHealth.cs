using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    private void Start() {
        health = maxHealth;
    }

    public void UpdateHealth(float amount) {
        health += amount;

        if (health > maxHealth) {
            health = maxHealth;
        }

        if (health <= 0) {
            health = 0f;
            Die();
        }
    }

    private void Die() {

        // idk jakas animacja czyc os uwu

        Destroy(gameObject);
    }
}
