using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class FinishColectable : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.itemList == 7){
                Debug.Log("Estojo");
                FinishHUD.Instance.ShowUIWin();
            }
        }
    }
}