using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class StartGameColectable : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Buceta");
        }
    }
}