using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        float moveVertical = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector2 (moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);

        }
    }

}