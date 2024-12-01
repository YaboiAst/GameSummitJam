using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoveIt : MonoBehaviour
{
    [SerializeField] Transform movePivot;
    private Vector2 direction;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            direction = Vector2.zero;
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

    public void MoveTowards(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir);
        if (hit.collider.CompareTag(""))
        {
            
        }
    }
}
