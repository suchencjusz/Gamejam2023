using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public float damage = 1;

    private Rigidbody2D rb2D;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            rb2D.MovePosition(
                Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime)
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
            Vector2 biteDirection = (transform.position - other.transform.position).normalized;
            rb2D.AddForce(biteDirection * 1000f, ForceMode2D.Impulse);
        }
    }
}
