using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Swipe : MonoBehaviour
{


    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

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
                    //RightSwipe(); //Passa a função direto 
                }
                else
                {
                    //LeftSwipe();
                }
            }
            else
            {
                if (inputVector.y > 0)
                {
                    //UpSwipe();
                }
                else
                {
                    //DownSwipe();
                }
            }
        }

    }

}