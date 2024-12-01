using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FinishHUD : MonoBehaviour
{
    public static FinishHUD Instance;

    public CanvasGroup cGroupWin, cGroupLose;
    public Button buttonWin;
    public Button buttonLose;

    public string nextSceneName;
    
    private void Awake()
    {
        Instance ??= this;
        HideUI();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        buttonWin.onClick.AddListener(OnWinButtonClick);
        buttonWin.interactable = false;
        
        buttonLose.onClick.AddListener(OnLoseButtonClick);
        buttonLose.interactable = false;
    }

    public void ShowUIWin()
    {
        cGroupWin.alpha = 1;
        buttonWin.interactable = true;
    }

    public void ShowUILose()
    {
        cGroupLose.alpha = 1;
        buttonLose.interactable = true;
    }
    
    public void HideUI()
    {
        cGroupWin.alpha = 0;
        cGroupWin.interactable = false;
        cGroupWin.blocksRaycasts = false;
        
        cGroupLose.alpha = 0;
        cGroupLose.interactable = false;
        cGroupLose.blocksRaycasts = false;
    }

    private void OnWinButtonClick()
    {
        // Win button logic
        Debug.Log("Winner winner chicken dinner!");
        GameManager.Instance.resetColectable();
        SceneManager.LoadScene("Scenes/TestCoins");
    }

    private void OnLoseButtonClick()
    {
        // Lose button logic
        Debug.Log("Burro burro burro lixo merda podre");
    }
}