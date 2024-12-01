using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    [Serializable]
    public class MoveCommand
    {
        [Dropdown(nameof(GetVectorValues))]
        public Vector2 direction;
        
        private DropdownList<Vector2> GetVectorValues()
        {
            return new DropdownList<Vector2>()
            {
                { "Right",   Vector2.right },
                { "Left",    Vector2.left },
                { "Up",      Vector2.up },
                { "Down",    Vector2.down }
            };
        }
    }
    
    [SerializeField] private float speed;
    [SerializeField] private List<MoveCommand> commandList;
    [SerializeField] private float delayBetweenMoves;
    
    [SerializeField] private Animator animator;
    
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(ExecuteMove());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (rb is null) return;
        
        rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.right;
        if (rb.velocity.x > 0)
        {
            direction = Vector2.right;
        }
        else if (rb.velocity.x < 0)
        {
            direction = Vector2.left;
        }
        else if (rb.velocity.y > 0)
        {
            direction = Vector2.up;
        }
        else if (rb.velocity.y < 0)
        {
            direction = Vector2.down;
        }
        
        
        if (rb.velocity != Vector2.zero)
        {
            var hit = Physics2D.Raycast(transform.position, direction, distance: 1.5f);
            if (hit.collider is not null && hit.collider.CompareTag("Wall"))
            {
                animator.transform.up = -direction;
                rb.velocity = Vector2.zero;
                direction = Vector2.zero;
                animator.SetTrigger("Landed");
            }
        }
    }

    IEnumerator ExecuteMove()
    {
        foreach (var command in commandList)
        {
            rb.AddForce(command.direction * (speed));
            yield return new WaitForSeconds(delayBetweenMoves);
        }
    }
}
