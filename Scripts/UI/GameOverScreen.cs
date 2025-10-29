using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.main.OnGameOver += ToggleGameOverPanel;
    }
    // Game Over Screen
    
    public void ToggleGameOverPanel()
    {
        GameOverPanel.SetActive(!GameOverPanel.activeSelf);
    }
    public void OnRePlayButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
    
}
