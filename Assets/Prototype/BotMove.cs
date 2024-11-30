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
    
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(ExecuteMove());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (rb is null) return;
         
        rb.velocity = Vector2.zero;
    }

    IEnumerator ExecuteMove()
    {
        foreach (var command in commandList)
        {
            rb.AddForce(command.direction * (speed * 1000f));
            yield return new WaitForSeconds(delayBetweenMoves);
        }
    }
}
