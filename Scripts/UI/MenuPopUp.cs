using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Menu class handles the shop menu open and close button, and the currency text
public class MenuPopUp : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] TextMeshProUGUI LifeCountText;
    [SerializeField] Animator animator;
    
    private bool isMenuOpen = true;

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("MenuOpen", isMenuOpen);
    }

    private void Update()
    {
        // Update the currency UI text every frame
        currencyUI.text = LevelManager.main.currency.ToString();
    }
/*
    private void UpdateWaveCountText()
    {
        waveCountText.text = EnemySpawner.GetWaveCount().ToString();
    }

    private void UpdateLifeCountText()
    {
        
    }
  */ 
}