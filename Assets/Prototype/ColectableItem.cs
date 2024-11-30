using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ColectableItem : MonoBehaviour {
    

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");
            GameManager.Instance.addColectable();
            Destroy(gameObject);
        }
    }

}