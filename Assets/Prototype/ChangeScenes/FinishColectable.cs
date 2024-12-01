using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class FinishColectable : MonoBehaviour
{

    [SerializeField] private int pointsUntilWin;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.itemList == pointsUntilWin){
                FinishHUD.Instance.ShowUIWin();
            }
        }
        else if (other.gameObject.CompareTag("Bot"))
        { 
            FinishHUD.Instance.ShowUILose();   
        }
    }
}