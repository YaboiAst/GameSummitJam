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

<<<<<<< Updated upstream
=======
    public AudioClip collectionSound; 

    [SerializeField] private Animator animator;

    private Vector3 unstuckPosition;
    
>>>>>>> Stashed changes
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 direction;
    private void Update()
    {
        var movementVector = new Vector2(0, 0);
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        if (movementVector == Vector2.zero) return;
        
        if (Math.Abs(movementVector.x) > Math.Abs(movementVector.y))
            direction = movementVector.x > 0 ? Vector2.right : Vector2.left;
        else
<<<<<<< Updated upstream
            direction = movementVector.y > 0 ? Vector2.up : Vector2.down;

        if (rb.velocity != Vector2.zero) return;
        rb.AddForce(direction * (speed * Time.deltaTime), ForceMode2D.Impulse);
=======
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
            // if (movementVector == Vector2.zero) return;
        
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
            
            if (direction == Vector2.zero) return;
            if (direction == -1 * ((Vector2) animator.transform.up)) return;
            
            var hit = Physics2D.Raycast(transform.position, direction, distance: 1.5f);
            if (hit.collider is not null && hit.collider.CompareTag("Wall"))
            {
                animator.transform.up = -direction;
                direction = Vector2.zero;
                rb.velocity = Vector2.zero;
                return;
            }
            animator.SetTrigger("Dash");
            GetComponent<AudioSource>().PlayOneShot(collectionSound);
            
            animator.transform.right = direction;
            rb.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
>>>>>>> Stashed changes
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.up = -direction;
        rb.velocity = Vector2.zero;
    }
}
