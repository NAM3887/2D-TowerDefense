using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionsButtonPressed()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
    
}
