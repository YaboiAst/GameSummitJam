using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

<<<<<<< Updated upstream:Assets/Prototype/FinishColectable.cs
public class FinishColectable : MonoBehaviour {
=======
public class FinishColectable : MonoBehaviour
{

    [SerializeField] private int pointsUntilWin;
    public AudioClip collectionSound; 
>>>>>>> Stashed changes:Assets/Prototype/ChangeScenes/FinishColectable.cs
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream:Assets/Prototype/FinishColectable.cs
            if (GameManager.Instance.itemList == 7){
                Debug.Log("Estojo");
                FinishHUD.Instance.ShowUIWin();
            }
        }
=======
            if (GameManager.Instance.itemList == pointsUntilWin){
                GetComponent<AudioSource>().PlayOneShot(collectionSound);
                FinishHUD.Instance.ShowUIWin();
            }
        }
        else if (other.gameObject.CompareTag("Bot"))
        { 
            GetComponent<AudioSource>().PlayOneShot(collectionSound);
            FinishHUD.Instance.ShowUILose();   
        }
>>>>>>> Stashed changes:Assets/Prototype/ChangeScenes/FinishColectable.cs
    }
}