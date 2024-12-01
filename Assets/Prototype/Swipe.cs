using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Swipe : MonoBehaviour
{

    private PlayerMove playerMove;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake() {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            Vector2 inputVector = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
            {
                if(inputVector.x > 0)
                {
                    playerMove.moveRight();
                }
                else
                {
                    playerMove.moveLeft();
                }
            }
            else
            {
                if (inputVector.y > 0)
                {
                    playerMove.moveUp();
                }
                else
                {
                    playerMove.moveDown();
                }
            }
        }

    }

}