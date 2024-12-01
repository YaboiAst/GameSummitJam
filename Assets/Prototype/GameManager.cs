using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance;

    private void Awake() {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }

        
    }
    public int itemList{get; private set;}


    public void addColectable(){
        itemList++;
    }

    public void resetColectable(){
        itemList = 0;
    }
    

}