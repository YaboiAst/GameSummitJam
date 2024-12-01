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

    public Canvas canvas;
    public Button buttonWin;
    public Button buttonLose;

    public CanvasGroup canvasGroup;


    private void Awake()
    {
        Instance = this;
        HideUI();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        buttonWin.onClick.AddListener(OnWinButtonClick);
        buttonLose.onClick.AddListener(OnLoseButtonClick);
    }

    public void ShowUIWin()
    {
        canvasGroup.alpha = 1;
        canvas.enabled = true;
        buttonWin.enabled = true;
    }

    public void HideUI()
    {
        canvasGroup.alpha = 0;
    }

    private void OnWinButtonClick()
    {
        // Win button logic
        Debug.Log("Winner winner chicken dinner!");
        GameManager.Instance.resetColectable();
        SceneManager.LoadScene("Scenes/joao");
    }

    private void OnLoseButtonClick()
    {
        // Lose button logic
        Debug.Log("Burro burro burro lixo merda podre");
    }
}