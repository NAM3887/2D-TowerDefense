using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] TextMeshProUGUI livesCountText;
    [SerializeField] Animator animator;
    
    
    private bool isMenuOpen = true;

    // Update text boxes on start
    private void Start()
    {
        LevelManager.main.OnLivesChanged += UpdateLivesText;
        LevelManager.main.OnWaveChanged += UpdateWaveText;
        LevelManager.main.OnCurrencyChanged += UpdateCurrencyText;
        
        UpdateLivesText(LevelManager.main.livesCount);
        UpdateWaveText(LevelManager.main.currWave);
        UpdateCurrencyText(LevelManager.main.currency);
    }
    
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("MenuOpen", isMenuOpen);
    }
         
    public void UpdateWaveText(int currentWave)
    {
        // Update the wave text
        waveCountText.text = "Wave: " + currentWave.ToString();
    }
    public void UpdateLivesText(int currentLives)
    {
        // Update the life 
        livesCountText.text = "Lives: " + currentLives.ToString();
    }

    public void UpdateCurrencyText(int currency)
    {
        // Update the currency UI text every frame
        currencyUI.text = LevelManager.main.currency.ToString();
    }
    
}