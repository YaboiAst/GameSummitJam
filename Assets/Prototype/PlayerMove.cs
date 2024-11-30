using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    // private Tween moveTween;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movementVector = new Vector2(0, 0);
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        if (movementVector == Vector2.zero) return;
        
        Vector2 direction;
        
        if (Math.Abs(movementVector.x) > Math.Abs(movementVector.y))
            direction = movementVector.x > 0 ? Vector2.right : Vector2.left;
        else
            direction = movementVector.y > 0 ? Vector2.up : Vector2.down;

        if (rb.velocity != Vector2.zero) return;
        rb.AddForce(direction * (speed * Time.deltaTime), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.velocity = Vector2.zero;
    }
}
