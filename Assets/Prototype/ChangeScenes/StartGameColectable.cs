using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameColectable : MonoBehaviour
{

    [SerializeField] private bool isStart;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (isStart)
            {
                SceneManager.LoadScene("Fase1");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}