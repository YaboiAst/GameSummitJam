using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    private Vector3 unstuckPosition;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        unstuckPosition = transform.position;
    }

    private Vector2 direction;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            direction = Vector2.zero;
            transform.position = unstuckPosition;
            animator.transform.up = Vector3.up;
        }
        
        var movementVector = new Vector2(0, 0);
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        if (movementVector == Vector2.zero) return;
        
        if (Math.Abs(movementVector.x) > Math.Abs(movementVector.y))
        {
            if(movementVector.x > 0)
                moveRight();
            else
                moveLeft();
        }
        else
        {
            if(movementVector.y > 0)
                moveUp();
            else
                moveDown();
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero)
        {
            var hit = Physics2D.Raycast(transform.position, direction, distance: 1.2f);
            if (hit.collider is not null && hit.collider.CompareTag("Wall"))
            {
                animator.transform.up = -direction;
                direction = Vector2.zero;
                rb.velocity = Vector2.zero;
                animator.SetTrigger("Landed");
            }
        }
        else
        {
            if (direction == Vector2.zero) return;
            if (direction == -1 * ((Vector2) animator.transform.up)) return;
            
            var hit = Physics2D.Raycast(transform.position, direction, distance: 1.2f);
            if (hit.collider is not null && hit.collider.CompareTag("Wall"))
            {
                animator.transform.position = new Vector3(animator.transform.position.x,
                    animator.transform.position.y, animator.transform.position.z);
                animator.transform.up = -direction;
                direction = Vector2.zero;
                rb.velocity = Vector2.zero;
                return;
            }
            animator.SetTrigger("Dash");
            
            animator.transform.right = direction;
            rb.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }

    public void moveRight()
    {
        direction = Vector2.right;
    }

    public void moveLeft()
    {
        direction = Vector2.left;
    }

    public void moveUp()
    {
        direction = Vector2.up;
    }

    public void moveDown()
    {
        direction = Vector2.down;
    }
}
