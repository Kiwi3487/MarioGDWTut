using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlower : MonoBehaviour
{
    public float speed = 5f;
    public float lifespan = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goomba")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Koopa")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
